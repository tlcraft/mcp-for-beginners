<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9730a53698bf9df8166d0080a8d5b61f",
  "translation_date": "2025-06-02T19:55:59+00:00",
  "source_file": "05-AdvancedTopics/mcp-scaling/README.md",
  "language_code": "fi"
}
-->
## Hajautettu arkkitehtuuri

Hajautetut arkkitehtuurit koostuvat useista MCP-solmuista, jotka toimivat yhdessä käsitelläkseen pyyntöjä, jakaakseen resursseja ja tarjotakseen vikasietoisuutta. Tämä lähestymistapa parantaa skaalautuvuutta ja vikasietoisuutta, kun solmut voivat kommunikoida ja koordinoida hajautetun järjestelmän kautta.

Katsotaan esimerkkiä siitä, miten toteuttaa hajautettu MCP-palvelinarkkitehtuuri käyttäen Redis:iä koordinointiin.

## Mitä seuraavaksi

- [Turvallisuus](../mcp-security/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, otathan huomioon, että automaattiset käännökset saattavat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäisellä kielellä tulee pitää virallisena lähteenä. Tärkeissä asioissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai virhetulkinnoista.