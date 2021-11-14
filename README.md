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

#### Architectural considerations
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


