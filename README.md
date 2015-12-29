# netexp_201507
# Project: App: Basisscholen in Gent

### Doelstelling

Een app die ouders helpt om een basisschool te kiezen in Gent.

### Functionele requirements
  - Lijst afbeelden van alle scholen, waarop doorgeklikt kan worden naar een detail
  - Een detail per school afbeelden
  - Afstand van huidige locatie tot de school berekenen in vogelvlucht en weergeven in het detail

### Technische requirements
  - Een (zelf te schrijven) WebApi (op Azure) communiceert (via JSON) met de open data site. Op deze manier blijft de data beschikbaar indien de open data site offline is. De app haalt zijn data op via JSON bij de WebApi.
  - Gebruik van Xamarin.forms om UWP applicatie te maken

### JSON Bron

http://datatank.stad.gent/4/onderwijsopvoeding/basisscholen.json

