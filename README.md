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
The following styles are demonstrated in this repository:

### Package by Layer
This style packages the classes by their technological layer (Presentation, Services and Infrastructure).

Packaging by layer has certain pros and cons as well as a few areas where the developers can make a choice.

#### Encapsulation
To maximize encapsulation, each layer only exposes their interfaces.

Often this style exposes too much detail of models to different parts of the application.
While only the interfaces are exposed, the shipping and order services are tightly coupled.
The order service needs to create the shipment and the shipping service requests the entire order model, even though it only needs the ID.

Both of these issues can of course be remedied, but it is implemented this way as this is a common mistake when using this architectural style.

#### Testability
To make the internal implementations testable I can either use the IServiceCollection or create a separate factory.

Ideally, to test product logic I shouldn't care about the functionality of the shipping service. However, the requirements make it sound like I should test it this way. Also, they may be considered a unit as they are part of the same package.

#### Models
Each layer has their own models. Alternatively, each layer could use the model of their dependency:
- _Services_ can use the models _Infrastructure_.
- _Web_ can use the models from both _Services_ and _Infrastructure_.

In this demo, I chose for separate models for each layer to provide an API that can easily be versioned.
Considering how identical the models are, I can also use AutoMapper to map between them.

### Package by Feature
Packaging by feature has certain pros and cons as well as a few areas where the developers can make a choice.

One of the advantages of packaging by feature is that developers can decide which architecture to adhere to within each slice/feature. In this demonstration, the Order slice does not have any other classes except for the Order model and the OrderController. If more business logic is added, developers might want to consider creating additional classes.

#### Encapsulation
As the shipping logic is also called from the Order slice, I decided to add a separate ShippingService. But again, only exposing the interface to maximize *encapsulation*.

As the models are now separated, the shipping service cannot use the Order model inappropriately any more. Instead, the Shipping slice only asks for the order ID.

Like packaging by layer, the Order slice still depends on the Shipping slice. This could be remedied by an event bus or a pub/sub pattern.

#### Testability
To make the internal implementations testable, I created a factory for the ShippingService. The OrderController can easily be tested directly.

Now that the Shipping service is separated from the Order service, I no longer care about the exact shipment that is created in the Order service. Instead I only validate that I asked the Shipping slice to ship our product.

In my opinion, the tests convey a better message than in the packaged by layer approach.

Swapping out the data access for an in-memory database or mocked repository is unfortunately impossible, unless you provide the test project access to the internal interfaces.

#### Models
Slices define their own models and are expected to carefully think what they expose to the outside (either as input parameters or as output values).

### Hexagonal Architecture
The hexagonal architecture looks like packaging by layer. The greatest change is the inversion of dependencies; the _presentation_ and _infrastructure_ layer both depend on the _domain_.

This architecture has certain pros and cons as well as a few areas where the developers can make a choice.

#### Encapsulation
To maximize encapsulation, each layer only exposes their interfaces.

Often this style exposes too much detail of models to different parts of the application.  While only the interfaces are exposed, the shipping and order services are tightly coupled.
The order service needs to create the shipment and the shipping service requests the entire order model, even though it only needs the ID. This can be prevented by also packaging by feature.

#### Testability
To make the internal implementations testable I can either use the IServiceCollection or create a separate factory.

The advantage of this style over packaging by layer is that the tests for the _domain_ have no dependency any more on the _infrastructure_.

#### Models
The models live in the _domain_ layer. Both the _presentation_ and _infrastructure_ layers use these models.

In this demo, I chose for additional models in the _presentation_ layer to provide an API that can easily be versioned.
Considering how identical the models are, I can also use AutoMapper to map between the _web_ and _domain_ models.

### Package by Component
Packaging component is similar to packaging by feature.The major difference is that the interfaces of the services are exposed. This means that they can be used directly instead of only via the _presentation_ layer. Most implementations I've seen of [Vertical Slice Architecture](https://jimmybogard.com/vertical-slice-architecture/) actually do something similar. They utilize a library like [Mediatr](https://github.com/jbogard/MediatR) to allow both controllers and other components to use their functionality.

This architecture has certain pros and cons as well as a few areas where the developers can make a choice.

#### Encapsulation
This style hides functionality behind the interface of the services.

This has the benefit that other components that want to use this functionality are not coupled to the _presentation_ layer of other components while still keeping the _infrastructure_ layer unaccessible.

#### Testability
The disadvantage of this approach is that, like packaging by feature, it's impossible to unit test unless you provide the test project access to the internal interfaces for data access.

Other than that, the tests might be easier to write than in the package by feature style, as we can test the _presentation_ layer separate from the _domain_ layer.

#### Models
Models are put in the components. But like with the other styles, you might want to opt for separate models in the _presentation_ layer, so that changes in the component do not affect the presentation.

## Remarks
The implementations are not optimal, many of the flaws can be solved without changing the architecture. InsteadI chose to show patterns that I have experienced and read about when using the architectural styles.

In the end, these are just architectural patterns, they do not put hard restrictions on the final implementation. They do have certain [affordances](https://sandimetz.com/blog/2018/21/what-does-oo-afford). Depending on the chosen architecture, certain patterns/issues are more likely to arise than others.

Also, in more complicated applications, I would personally use an in-process event bus so that the _OrderService_ no longer has a dependency on the _ShippingService_. Instead, it's the _Shipping_ domain's responsibility to know when an order is placed and to create the shipment. This also makes it easier to create separate units of deployment from these two domains.

For more information about these styles and the ins and outs of them, I recommend watching Simon Brown's [Modular Monolith](https://www.youtube.com/watch?v=5OjqD-ow8GE) talk.

## Questions?
If you have any questions or feel like certain things are mispresented. Feel free to open an issue or a PR!
