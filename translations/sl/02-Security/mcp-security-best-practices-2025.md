<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c3f4ea5732d64bf965e8aa2907759709",
  "translation_date": "2025-07-17T13:47:49+00:00",
  "source_file": "02-Security/mcp-security-best-practices-2025.md",
  "language_code": "sl"
}
-->
# MCP Varnostne Najboljše Prakse - Posodobitev julij 2025

## Celovite varnostne najboljše prakse za implementacije MCP

Pri delu z MCP strežniki upoštevajte naslednje varnostne najboljše prakse za zaščito vaših podatkov, infrastrukture in uporabnikov:

1. **Preverjanje vhodnih podatkov**: Vedno preverjajte in čistite vhodne podatke, da preprečite injekcijske napade in težave z zmedo pooblaščenca.
   - Uvedite strogo preverjanje vseh parametrov orodij
   - Uporabite preverjanje shem, da zagotovite, da so zahteve skladne s pričakovanimi formati
   - Filtrirajte morebitno zlonamerno vsebino pred obdelavo

2. **Nadzor dostopa**: Uvedite ustrezno avtentikacijo in avtorizacijo za vaš MCP strežnik z natančno določenimi dovoljenji.
   - Uporabite OAuth 2.0 z uveljavljenimi ponudniki identitet, kot je Microsoft Entra ID
   - Uvedite nadzor dostopa na podlagi vlog (RBAC) za MCP orodja
   - Nikoli ne uvajajte lastne avtentikacije, če obstajajo uveljavljene rešitve

3. **Varnostna komunikacija**: Za vso komunikacijo z MCP strežnikom uporabljajte HTTPS/TLS in razmislite o dodatnem šifriranju za občutljive podatke.
   - Kjer je mogoče, konfigurirajte TLS 1.3
   - Uvedite pritrjevanje certifikatov za kritične povezave
   - Redno menjajte certifikate in preverjajte njihovo veljavnost

4. **Omejevanje hitrosti**: Uvedite omejevanje hitrosti, da preprečite zlorabe, DoS napade in upravljate porabo virov.
   - Nastavite primerne omejitve zahtev glede na pričakovane vzorce uporabe
   - Uvedite postopne odzive na pretirane zahteve
   - Razmislite o omejitvah hitrosti za posamezne uporabnike glede na status avtentikacije

5. **Dnevnik in nadzor**: Spremljajte vaš MCP strežnik za sumljive aktivnosti in uvedite celovite revizijske sledi.
   - Beležite vse poskuse avtentikacije in klice orodij
   - Uvedite opozarjanje v realnem času za sumljive vzorce
   - Poskrbite, da so dnevniki varno shranjeni in ne morejo biti spremenjeni

6. **Varnostno shranjevanje**: Zaščitite občutljive podatke in poverilnice z ustreznim šifriranjem v mirovanju.
   - Uporabljajte ključnice ali varne shrambe poverilnic za vse skrivnosti
   - Uvedite šifriranje na ravni polj za občutljive podatke
   - Redno menjajte šifrirne ključe in poverilnice

7. **Upravljanje žetonov**: Preprečite ranljivosti pri prenosu žetonov z validacijo in čiščenjem vseh vhodov in izhodov modela.
   - Uvedite validacijo žetonov na podlagi trditev o občinstvu
   - Nikoli ne sprejemajte žetonov, ki niso izrecno izdani za vaš MCP strežnik
   - Uvedite pravilno upravljanje življenjske dobe žetonov in njihovo menjavo

8. **Upravljanje sej**: Uvedite varno upravljanje sej, da preprečite prevzem in fiksacijo sej.
   - Uporabljajte varne, nedeterministične ID-je sej
   - Povežite seje z informacijami, specifičnimi za uporabnika
   - Uvedite pravilno potekanje in menjavo sej

9. **Izolacija izvajanja orodij**: Zaženite izvajanje orodij v izoliranih okoljih, da preprečite lateralno širjenje v primeru kompromisa.
   - Uvedite izolacijo z vsebniki za izvajanje orodij
   - Uporabite omejitve virov, da preprečite napade z izčrpavanjem virov
   - Uporabljajte ločene kontekste izvajanja za različna varnostna področja

10. **Redni varnostni pregledi**: Redno izvajajte varnostne preglede vaših MCP implementacij in odvisnosti.
    - Načrtujte redno penetracijsko testiranje
    - Uporabljajte avtomatizirana orodja za odkrivanje ranljivosti
    - Posodabljajte odvisnosti, da odpravite znane varnostne težave

11. **Filtriranje varnosti vsebine**: Uvedite filtre varnosti vsebine za vhodne in izhodne podatke.
    - Uporabljajte Azure Content Safety ali podobne storitve za zaznavanje škodljive vsebine
    - Uvedite tehnike zaščite pozivov, da preprečite injekcijo pozivov
    - Pregledujte ustvarjeno vsebino zaradi morebitnega uhajanja občutljivih podatkov

12. **Varnost dobavne verige**: Preverite integriteto in pristnost vseh komponent v vaši AI dobavni verigi.
    - Uporabljajte podpisane pakete in preverjajte podpise
    - Uvedite analizo programske opreme (SBOM)
    - Spremljajte zlonamerne posodobitve odvisnosti

13. **Zaščita definicij orodij**: Preprečite zastrupitev orodij z varovanjem definicij in metapodatkov orodij.
    - Preverjajte definicije orodij pred uporabo
    - Spremljajte nepričakovane spremembe metapodatkov orodij
    - Uvedite preverjanja integritete definicij orodij

14. **Dinamično spremljanje izvajanja**: Spremljajte vedenje MCP strežnikov in orodij med izvajanjem.
    - Uvedite analizo vedenja za odkrivanje anomalij
    - Nastavite opozorila za nepričakovane vzorce izvajanja
    - Uporabljajte tehnike samovarovanja aplikacij med izvajanjem (RASP)

15. **Načelo najmanjših privilegijev**: Zagotovite, da MCP strežniki in orodja delujejo z minimalnimi potrebnimi dovoljenji.
    - Dodeljujte le specifična dovoljenja, potrebna za posamezno operacijo
    - Redno pregledujte in revidirajte uporabo dovoljenj
    - Uvedite dostop po potrebi za administrativne funkcije

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za avtomatski prevod AI [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da lahko avtomatski prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Za morebitne nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.