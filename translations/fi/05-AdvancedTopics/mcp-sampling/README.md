<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b0de03f7a3ff0204d8356bc61325c459",
  "translation_date": "2025-06-02T20:05:06+00:00",
  "source_file": "05-AdvancedTopics/mcp-sampling/README.md",
  "language_code": "fi"
}
-->
## Deterministinen otanta

Sovelluksissa, jotka vaativat johdonmukaisia tuloksia, deterministinen otanta takaa toistettavat lopputulokset. Tämä saavutetaan käyttämällä kiinteää satunnaissiementä ja asettamalla lämpötila nollaan.

Tarkastellaan alla olevaa esimerkkitoteutusta, joka havainnollistaa determinististä otantaa eri ohjelmointikielillä.

## Dynaaminen otantakonfiguraatio

Älykäs otanta mukauttaa parametreja kunkin pyynnön kontekstin ja vaatimusten mukaan. Tämä tarkoittaa parametrien, kuten lämpötilan, top_p:n ja rangaistusten, dynaamista säätämistä tehtävätyypin, käyttäjäasetusten tai aiemman suorituskyvyn perusteella.

Katsotaan, miten dynaaminen otanta toteutetaan eri ohjelmointikielillä.

## Mitä seuraavaksi

- [Skaalaus](../mcp-scaling/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, ole hyvä ja huomioi, että automaattiset käännökset saattavat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.