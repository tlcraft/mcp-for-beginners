<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e5ea5e7582f70008ea9bec3b3820f20a",
  "translation_date": "2025-05-17T14:33:09+00:00",
  "source_file": "04-PracticalImplementation/samples/java/containerapp/README.md",
  "language_code": "sl"
}
-->
## Sistem arhitektura

Ta projekt prikazuje spletno aplikacijo, ki preverja varnost vsebine, preden uporabniške zahteve pošlje kalkulatorski storitvi prek Model Context Protocol (MCP).

### Kako deluje

1. **Uporabniški vnos**: Uporabnik v spletni vmesnik vnese zahtevo za izračun.
2. **Preverjanje varnosti vsebine (vnos)**: Zahteva se analizira z Azure Content Safety API.
3. **Odločitev o varnosti (vnos)**:
   - Če je vsebina varna (resnost < 2 v vseh kategorijah), se nadaljuje do kalkulatorja.
   - Če je vsebina označena kot potencialno škodljiva, se proces ustavi in vrne opozorilo.
4. **Integracija kalkulatorja**: Varna vsebina se obdela z LangChain4j, ki komunicira z MCP strežnikom kalkulatorja.
5. **Preverjanje varnosti vsebine (izhod)**: Odgovor bota se analizira z Azure Content Safety API.
6. **Odločitev o varnosti (izhod)**:
   - Če je odgovor bota varen, se prikaže uporabniku.
   - Če je odgovor bota označen kot potencialno škodljiv, se zamenja z opozorilom.
7. **Odgovor**: Rezultati (če so varni) se prikažejo uporabniku skupaj z obema analizama varnosti.

## Uporaba Model Context Protocol (MCP) s kalkulatorskimi storitvami

Ta projekt prikazuje, kako uporabiti Model Context Protocol (MCP) za klicanje kalkulatorskih MCP storitev iz LangChain4j. Implementacija uporablja lokalni MCP strežnik, ki teče na portu 8080 za zagotavljanje kalkulatorskih operacij.

### Nastavitev storitve Azure Content Safety

Pred uporabo funkcij varnosti vsebine morate ustvariti vir storitve Azure Content Safety:

1. Prijavite se v [Azure Portal](https://portal.azure.com)
2. Kliknite "Create a resource" in poiščite "Content Safety"
3. Izberite "Content Safety" in kliknite "Create"
4. Vnesite edinstveno ime za vaš vir
5. Izberite vašo naročnino in skupino virov (ali ustvarite novo)
6. Izberite podporano regijo (preverite [Razpoložljivost regij](https://azure.microsoft.com/en-us/global-infrastructure/services/?products=cognitive-services) za podrobnosti)
7. Izberite ustrezno cenovno stopnjo
8. Kliknite "Create" za namestitev vira
9. Ko je namestitev končana, kliknite "Go to resource"
10. V levem podoknu, pod "Resource Management", izberite "Keys and Endpoint"
11. Kopirajte enega od ključev in URL končne točke za uporabo v naslednjem koraku

### Konfiguriranje okoljskih spremenljivk

Nastavite okoljsko spremenljivko `GITHUB_TOKEN` za avtentikacijo modelov GitHub:
```sh
export GITHUB_TOKEN=<your_github_token>
```

Za funkcije varnosti vsebine nastavite:
```sh
export CONTENT_SAFETY_ENDPOINT=<your_content_safety_endpoint>
export CONTENT_SAFETY_KEY=<your_content_safety_key>
```

Te okoljske spremenljivke aplikacija uporablja za avtentikacijo z Azure Content Safety storitvijo. Če te spremenljivke niso nastavljene, bo aplikacija uporabila nadomestne vrednosti za demonstracijske namene, vendar funkcije varnosti vsebine ne bodo pravilno delovale.

### Zagon kalkulatorskega MCP strežnika

Pred zagonom odjemalca morate zagnati kalkulatorski MCP strežnik v SSE načinu na localhost:8080.

## Opis projekta

Ta projekt prikazuje integracijo Model Context Protocol (MCP) z LangChain4j za klicanje kalkulatorskih storitev. Ključne funkcije vključujejo:

- Uporaba MCP za povezavo s kalkulatorsko storitvijo za osnovne matematične operacije
- Dvoplastno preverjanje varnosti vsebine na uporabniških zahtevah in odgovorih bota
- Integracija z GitHubovim modelom gpt-4.1-nano prek LangChain4j
- Uporaba Server-Sent Events (SSE) za MCP prenos

## Integracija varnosti vsebine

Projekt vključuje celovite funkcije varnosti vsebine, da zagotovi, da so tako uporabniški vnosi kot sistemski odgovori brez škodljive vsebine:

1. **Preverjanje vnosa**: Vse uporabniške zahteve se analizirajo za kategorije škodljive vsebine, kot so sovražni govor, nasilje, samopoškodovanje in spolna vsebina pred obdelavo.

2. **Preverjanje izhoda**: Tudi pri uporabi potencialno necenzuriranih modelov sistem preveri vse generirane odgovore skozi iste filtre varnosti vsebine, preden jih prikaže uporabniku.

Ta dvoplastni pristop zagotavlja, da sistem ostane varen, ne glede na to, kateri AI model se uporablja, in ščiti uporabnike pred škodljivimi vnosi ter potencialno problematičnimi AI-generiranimi izhodi.

## Spletni odjemalec

Aplikacija vključuje uporabniku prijazen spletni vmesnik, ki uporabnikom omogoča interakcijo s sistemom Content Safety Calculator:

### Značilnosti spletnega vmesnika

- Preprost, intuitiven obrazec za vnos zahtev za izračun
- Dvoplastna validacija varnosti vsebine (vnos in izhod)
- Povratne informacije v realnem času o varnosti zahtev in odgovorov
- Barvno kodirani indikatorji varnosti za lažje razumevanje
- Čist, odziven dizajn, ki deluje na različnih napravah
- Primeri varnih zahtev za usmerjanje uporabnikov

### Uporaba spletnega odjemalca

1. Zaženite aplikacijo:
   ```sh
   mvn spring-boot:run
   ```

2. Odprite brskalnik in pojdite na `http://localhost:8087`

3. Vnesite zahtevo za izračun v predvideno besedilno polje (npr. "Izračunaj vsoto 24.5 in 17.3")

4. Kliknite "Submit" za obdelavo vaše zahteve

5. Oglejte si rezultate, ki bodo vključevali:
   - Analizo varnosti vsebine vaše zahteve
   - Izračunan rezultat (če je zahteva varna)
   - Analizo varnosti vsebine odgovora bota
   - Vsa varnostna opozorila, če je bil vnos ali izhod označen

Spletni odjemalec samodejno upravlja oba postopka preverjanja varnosti vsebine, kar zagotavlja, da so vse interakcije varne in primerne, ne glede na to, kateri AI model se uporablja.

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za prevajanje AI [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da se zavedate, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem maternem jeziku je treba obravnavati kot avtoritativni vir. Za kritične informacije se priporoča profesionalni prevod s strani človeka. Ne odgovarjamo za morebitne nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.