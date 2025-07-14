<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3cb0da3badd51d73ab78ebade2827d98",
  "translation_date": "2025-07-14T02:23:16+00:00",
  "source_file": "05-AdvancedTopics/mcp-sampling/README.md",
  "language_code": "fi"
}
-->
## Deterministinen otanta

Sovelluksissa, joissa tarvitaan johdonmukaisia tuloksia, deterministinen otanta takaa toistettavat tulokset. Tämä saavutetaan käyttämällä kiinteää satunnaissiementä ja asettamalla lämpötila nollaan.

Tarkastellaan alla olevaa esimerkkitoteutusta, joka havainnollistaa determinististä otantaa eri ohjelmointikielillä.

## Dynaaminen otantakonfiguraatio

Älykäs otanta mukauttaa parametreja kunkin pyynnön kontekstin ja vaatimusten mukaan. Tämä tarkoittaa parametrien, kuten lämpötilan, top_p:n ja rangaistusten, dynaamista säätämistä tehtävätyypin, käyttäjäasetusten tai aiemman suorituskyvyn perusteella.

Katsotaan, miten dynaaminen otanta toteutetaan eri ohjelmointikielillä.

## Mitä seuraavaksi

- [5.7 Skaalaus](../mcp-scaling/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä asioissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.