# netexp_201507
# Project: App: Basisscholen in Gent

### Doelstelling

Een app die ouders helpt om een basisschool te kiezen in Gent.

### Functionele requirements
  - Lijst afbeelden van alle scholen, waarop doorgeklikt kan worden naar een detail
  - Een detail per school afbeelden
  - Afstand van huidige locatie tot de school berekenen in vogelvlucht en weergeven in het detail
  - Rating geven aan de school + gemiddelde rating afbeelden.

### Technische requirements
  - Een (zelf te schrijven) WebApi (op Azure) communiceert (via JSON) met de open data site en schrijft deze objecten weg in een     database. Op deze manier blijft de data beschikbaar indien de open data site offline is. De apps halen hun data op via JSON      bij de WebApi.
  - Ratings van de scholen bijhouden
  - UWP applicatie (met Xamarin)
  - WPF applicatie

### JSON Bron

http://datatank.stad.gent/4/onderwijsopvoeding/basisscholen.json

