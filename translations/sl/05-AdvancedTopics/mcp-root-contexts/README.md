<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8311f46a35cf608c9780f39b62c9dc3f",
  "translation_date": "2025-07-14T02:08:04+00:00",
  "source_file": "05-AdvancedTopics/mcp-root-contexts/README.md",
  "language_code": "sl"
}
-->
## Primer: Implementacija korenskega konteksta za finančno analizo

V tem primeru bomo ustvarili korenski kontekst za sejo finančne analize, s čimer bomo pokazali, kako ohranjati stanje skozi več interakcij.

## Primer: Upravljanje korenskih kontekstov

Učinkovito upravljanje korenskih kontekstov je ključno za ohranjanje zgodovine pogovora in stanja. Spodaj je primer, kako implementirati upravljanje korenskih kontekstov.

## Korenski kontekst za večkrožno pomoč

V tem primeru bomo ustvarili korenski kontekst za sejo večkrožne pomoči, s čimer bomo pokazali, kako ohranjati stanje skozi več interakcij.

## Najboljše prakse za korenske kontekste

Tukaj je nekaj najboljših praks za učinkovito upravljanje korenskih kontekstov:

- **Ustvarjajte osredotočene kontekste**: Ustvarite ločene korenske kontekste za različne namene pogovora ali domene, da ohranite jasnost.

- **Določite politike poteka veljavnosti**: Uvedite politike za arhiviranje ali brisanje starih kontekstov, da upravljate prostor za shranjevanje in izpolnjujete politike hrambe podatkov.

- **Shranjujte relevantne metapodatke**: Uporabite metapodatke konteksta za shranjevanje pomembnih informacij o pogovoru, ki bi lahko bile kasneje uporabne.

- **Dosledno uporabljajte ID-je konteksta**: Ko je kontekst ustvarjen, dosledno uporabljajte njegov ID za vse povezane zahteve, da ohranite kontinuiteto.

- **Ustvarjajte povzetke**: Ko kontekst postane obsežen, razmislite o ustvarjanju povzetkov, ki zajamejo bistvene informacije in hkrati upravljajo velikost konteksta.

- **Implementirajte nadzor dostopa**: Za sisteme z več uporabniki uvedite ustrezne kontrole dostopa, da zagotovite zasebnost in varnost pogovornih kontekstov.

- **Obvladujte omejitve konteksta**: Zavedajte se omejitev velikosti konteksta in uvedite strategije za obravnavo zelo dolgih pogovorov.

- **Arhivirajte, ko je končano**: Arhivirajte kontekste, ko so pogovori zaključeni, da sprostite vire in hkrati ohranite zgodovino pogovora.

## Kaj sledi

- [5.5 Usmerjanje](../mcp-routing/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.