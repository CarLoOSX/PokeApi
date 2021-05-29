## Hace todos los puntos pedidos (40%)

#### El nombre del repositorio es el correcto (mdas-web-${nombre}_${apellido})

No, he tenido que renombrar el proyecto para poder hacerme un clone :-(

#### Permite obtener los detalles de un pokemon vía endpoint (datos + número de veces que se ha marcado como favorito)

OK

#### Actualiza el contador de favoritos vía eventos

OK

#### ¿Se controlan las excepciones de dominio? Y si se lanza una excepción desde el dominio, ¿se traduce en infraestructura a un código HTTP?

OK

#### Tests unitarios

No hay tests unitarios de la parte solicitada

#### Tests de aceptación

No hay tests de aceptación de la parte solicitada

#### Tests de integración

No hay tests de integración de la parte solicitada

**Puntuación: 15/40**

## Se aplican conceptos explicados (50%)

#### Separación correcta de capas (application, domain, infrastructure + BC/module/layer)

- La responsabilidad de crear el evento y añadirlo la tiene el agregado, no el caso de uso. El caso de uso tiene la
  responsabilidad de publicar el evento.

#### Aggregates + VOs

OK

#### No se trabajan con tipos primitivos en dominio

OK

#### Hay servicios de dominio

- No hay para la nueva funcionalidad, que sería el servicio de dominio responsable de buscar el pokemon, incrementar el
  número de veces que se ha marcado como favorito y guardarlo.

#### Hay use cases en aplicación reutilizables

OK

#### Se aplica el patrón repositorio

OK

#### Se usan subscribers

OK. Aunque la solución actual no es muy escalable, ya que está orientada a que haya solo un evento en todo el sistema,
cuando una arquitectura basada en eventos, escucha y lanza muchos eventos.

#### Se lanzan eventos de dominio

OK

#### Se utilizan object mothers

Como no hay tests, ¡no se utilizan object mothers!

**Puntuación: 43/50**

## Facilidad setup + README (10%)

#### El README contiene al menos los apartados "cómo ejecutar la aplicación", "cómo usar la aplicación"

OK

#### Es sencillo seguir el apartado "cómo ejecutar la aplicación"

OK

**Puntuación: 10/10**

## Extras

- Swagger +5
- Muy currado el readme +5

**Puntuación: +10**

## Observaciones

- El package de la clase `NotifyPokemonOnAddedToFavouriteListener` debería ser subscribers, listeners... no api ;-)

**PUNTUACIÓN FINAL: 78/100**
