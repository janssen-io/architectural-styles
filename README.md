# Architectural Styles

This repository displays a simple web API in four different architectural styles.
The purpose is to show what they look like, not to prove that one is better than the other.
Arguably, none of these styles are appropriate for the size of this demonstration.

## Requirements
The web API needs to support the following behavior:
- Place a new order
- Retrieve the status of the shipment related to the placed order

The source code also needs to be testable.

## Styles
The following four styles are demonstrated in this repository:

### Package by Layer
This style packages the classes by their technological layer (Web App/Entry point, Services and Infrastructure).

Packaging by layer has certain pros and cons as well as a few areas where the developers can make a choice.


**Encapsulation**
To maximize encapsulation, each layer only exposes their interfaces.

Often this style exposes too much detail of models to different parts of the application.
While only the interfaces are exposed, the shipping and order services are tightly coupled.
The order service needs to create the shipment and the shipping service requests the entire order model, even though it only needs the ID.

Both of these issues can of course be remedied, but it is implemented this way as this is a common mistake when using this architectural style.

**Testability**
To make the internal implementations testable we can either use the IServiceCollection or create a separate factory.

Ideally, to test product logic we shouldn't care about the functionality of the shipping service. However, the requirements make it sound like we should test it this way. Also, they may be considered a unit as they are part of the same package.

**Models**
Each layer has their own models. Alternatively, each layer could use the model of their dependency:
- _Services_ can use the models _Infrastructure_.
- _Web_ can use the models from both _Services_ and _Infrastructure_.

In this demo, I chose for separate models for each layer to provide an API that can easily be versioned.
Considering how identical the models are, we can also use AutoMapper to map between them.

### Package by Feature
Packaging by feature has certain pros and cons as well as a few areas where the developers can make a choice.

One of the advantages of packaging by feature is that developers can decide which architecture to adhere to within each slice/feature. In this demonstration, the Order slice does not have any other classes except for the Order model and the OrderController. If more business logic is added, developers might want to consider creating additional classes.

**Encapsulation**
As the shipping logic is also called from the Order slice, we decided to add a separate ShippingService. But again, only exposing the interface to maximize *encapsulation*.

As the models are now separated, the shipping service cannot use the Order model inappropriately any more. Instead, the Shipping slice only asks for the order ID.

Like packaging by layer, the Order slice still depends on the Shipping slice. This could be remedied by an event bus or a pub/sub pattern.

**Testability**
To make the internal implementations testable, we created a factory for the ShippingService. The OrderController can easily be tested directly.

Now that the Shipping service is separated from the Order service, we no longer care about the exact shipment that is created in the Order service. Instead we only validate that we asked the Shipping slice to ship our product.

In my opinion, the tests convey a better message than in the packaged by layer approach.

**Models**
Slices define their own models and are expected to carefully think what they expose to the outside (either as input parameters or as output values).

### Hexagonal Architecture
The hexagonal architecture looks like packaging by layer. The greatest change is the inversion of dependencies;the web and infrastructure layer both depend on the domain.

This architecture has certain pros and cons as well as a few areas where the developers can make a choice.

**Encapsulation**
To maximize encapsulation, each layer only exposes their interfaces.

Often this style exposes too much detail of models to different parts of the application.  While only the interfaces are exposed, the shipping and order services are tightly coupled.
The order service needs to create the shipment and the shipping service requests the entire order model, even though it only needs the ID. This can be prevented by also packaging by feature.

**Testability**
To make the internal implementations testable we can either use the IServiceCollection or create a separate factory.

The advantage of this style over packaging by layer is that the tests for the _domain_ have no dependency any more on the _infrastructure_.

**Models**
The models live in the _domain_ layer. Both the _web_ and _infrastructure_ layers use these models.

In this demo, we chose for additional models in the _web_ layer to provide an API that can easily be versioned.
Considering how identical the models are, we can also use AutoMapper to map between the _web_ and _domain_ models.
