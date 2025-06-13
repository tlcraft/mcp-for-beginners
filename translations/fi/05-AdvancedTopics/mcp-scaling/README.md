<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "cd973a4e381337c6a3ac2443e7548e63",
  "translation_date": "2025-06-13T00:17:07+00:00",
  "source_file": "05-AdvancedTopics/mcp-scaling/README.md",
  "language_code": "fi"
}
-->
## Jakautunut arkkitehtuuri

Jakautuneet arkkitehtuurit tarkoittavat useiden MCP-solmujen yhteistyötä pyyntöjen käsittelyssä, resurssien jakamisessa ja vikasietoisuuden varmistamisessa. Tämä lähestymistapa parantaa skaalautuvuutta ja vikasietoisuutta, kun solmut voivat kommunikoida ja koordinoida toimintaansa jakautuneen järjestelmän kautta.

Katsotaan esimerkkiä siitä, miten toteuttaa jakautunut MCP-palvelinarkkitehtuuri käyttäen Redis:iä koordinaatioon.

## Mitä seuraavaksi

- [5.8 Turvallisuus](../mcp-security/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, otathan huomioon, että automaattiset käännökset saattavat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulisi pitää virallisena lähteenä. Tärkeissä asioissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä johtuvista väärinymmärryksistä tai tulkinnoista.