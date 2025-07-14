<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "cd973a4e381337c6a3ac2443e7548e63",
  "translation_date": "2025-07-14T02:31:18+00:00",
  "source_file": "05-AdvancedTopics/mcp-scaling/README.md",
  "language_code": "fi"
}
-->
## Hajautettu arkkitehtuuri

Hajautetut arkkitehtuurit koostuvat useista MCP-solmuista, jotka toimivat yhdessä käsitelläkseen pyyntöjä, jakaakseen resursseja ja tarjotakseen vikasietoisuutta. Tämä lähestymistapa parantaa skaalautuvuutta ja vikasietoisuutta, kun solmut voivat kommunikoida ja koordinoida hajautetun järjestelmän kautta.

Katsotaan esimerkkiä siitä, miten toteuttaa hajautettu MCP-palvelinarkkitehtuuri käyttäen Redis:iä koordinointiin.

## Mitä seuraavaksi

- [5.8 Security](../mcp-security/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.