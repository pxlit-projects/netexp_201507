# netexp_201507
# Project: App: Basisscholen in Gent

### Doelstelling

Een app die het aantal verkeersborden in beeld brengt, en alzo een eventuele "wildgroei" van verkeersborden aangeeft.

### Functionele requirements
  - Lijst afbeelden van alle verkeersborden, waarop doorgeklikt kan worden naar een detail (eigenschappen zoals vorm ed)
  - Kaart afbeelden
  - Gebruiker kan een nieuw verkeersbord uploaden (app gebruikt huidige locatie als locatie van het bord)
  - Gebruiker- en overheidssaangegeven borden worden verschillend weergegeven 

### Technische requirements
  - Een (zelf te schrijven) WebApi (op Azure) communiceert (via JSON) met de open data site en schrijft deze objecten weg in een     database. Op deze manier blijft de data beschikbaar indien de open data site offline is. De apps halen hun data op via JSON      bij de WebApi.
  - Nieuwe door gebruikers toegevoegde verkeersborden bijhouden
  - UWP applicatie (met Xamarin)
  - WPF applicatie

### JSON Bron

http://datasets.antwerpen.be/v4/gis/verkeersbordpt.json

