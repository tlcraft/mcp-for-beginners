<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0a8086dc4bf89448f83e7936db972c42",
  "translation_date": "2025-05-17T11:41:50+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "hu"
}
-->
Most, hogy már többet tudunk az SSE-ről, építsünk egy SSE szervert.

## Gyakorlat: SSE szerver létrehozása

Ahhoz, hogy létrehozzuk a szerverünket, két dolgot kell szem előtt tartanunk:

- Használnunk kell egy webszervert, hogy elérhetővé tegyük a kapcsolat és az üzenetek végpontjait.
- Építsük fel a szerverünket úgy, ahogy szoktuk, amikor stdio-t használtunk, eszközökkel, erőforrásokkal és utasításokkal.

### -1- Szerver példány létrehozása

A szerver létrehozásához ugyanazokat a típusokat használjuk, mint a stdio esetében. Azonban a szállítási módhoz az SSE-t kell választanunk.

Haladjunk tovább a szükséges útvonalak hozzáadásával.

### -2- Útvonalak hozzáadása

Adjunk hozzá útvonalakat, amelyek kezelik a kapcsolatot és a bejövő üzeneteket.

Haladjunk tovább a szerver képességeinek hozzáadásával.

### -3- Szerver képességeinek hozzáadása

Most, hogy mindent meghatároztunk az SSE-hez, adjunk hozzá szerver képességeket, mint például eszközök, utasítások és erőforrások.

A teljes kódod így kell kinézzen:

Nagyszerű, van egy szerverünk SSE-vel, próbáljuk ki!

## Gyakorlat: SSE szerver hibakeresése az Inspectorral

Az Inspector egy nagyszerű eszköz, amit már láttunk egy korábbi leckében [Első szerver létrehozása](/03-GettingStarted/01-first-server/README.md). Nézzük meg, használhatjuk-e az Inspectort itt is:

### -1- Inspector futtatása

Az Inspector futtatásához először egy SSE szervert kell futtatnod, tehát tegyük ezt meg:

1. Futtasd a szervert

1. Futtasd az Inspectort

    > ![NOTE]
    > Ezt egy külön terminálablakban futtasd, mint amelyikben a szerver fut. Figyelj arra is, hogy az alábbi parancsot módosítanod kell, hogy illeszkedjen a szervered URL-jéhez.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Az Inspector futtatása minden futási környezetben ugyanúgy néz ki. Figyeld meg, hogy a szerver elérési útjának és a szerver indítási parancsának megadása helyett az URL-t adjuk meg, ahol a szerver fut, és megadjuk a `/sse` útvonalat is.

### -2- Az eszköz kipróbálása

Csatlakoztasd a szervert az SSE kiválasztásával a legördülő listában, és töltsd ki az URL mezőt, ahol a szervered fut, például http:localhost:4321/sse. Most kattints a "Connect" gombra. Ahogy korábban, válaszd ki az eszközök listázását, válassz ki egy eszközt, és adj meg bemeneti értékeket. Az eredménynek így kell kinéznie:

![SSE szerver fut az Inspectorban](../../../../translated_images/sse-inspector.12861eb95abecbfc82610f480b55901524fed1a6aca025bb948e09e882c48428.hu.png)

Nagyszerű, képes vagy dolgozni az Inspectorral, nézzük meg, hogyan tudunk dolgozni a Visual Studio Code-dal.

## Feladat

Próbálj meg több képességet hozzáadni a szerveredhez. Nézd meg [ezt az oldalt](https://api.chucknorris.io/) például egy eszköz hozzáadásához, amely egy API-t hív meg, te döntöd el, hogy nézzen ki a szervered. Jó szórakozást :)

## Megoldás

[Megoldás](./solution/README.md) Itt egy lehetséges megoldás működő kóddal.

## Legfontosabb tanulságok

A fejezet legfontosabb tanulságai a következők:

- Az SSE a stdio mellett a második támogatott szállítási mód.
- Az SSE támogatásához kezelni kell a bejövő kapcsolatokat és üzeneteket egy webes keretrendszer segítségével.
- Az Inspectort és a Visual Studio Code-ot is használhatod az SSE szerver fogyasztására, ugyanúgy, mint a stdio szerverek esetében. Figyeld meg, hogy van némi különbség a stdio és az SSE között. Az SSE esetében külön kell elindítanod a szervert, majd futtatnod az Inspector eszközt. Az Inspector eszköznél is van némi különbség, mivel meg kell adnod az URL-t.

## Minták

- [Java Kalkulátor](../samples/java/calculator/README.md)
- [.Net Kalkulátor](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulátor](../samples/javascript/README.md)
- [TypeScript Kalkulátor](../samples/typescript/README.md)
- [Python Kalkulátor](../../../../03-GettingStarted/samples/python)

## További források

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Mi a következő lépés

- Következő: [AI Toolkit kezdő lépések a VSCode-hoz](/03-GettingStarted/06-aitk/README.md)

**Felelősség kizárása**:  
Ezt a dokumentumot az AI fordítószolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordítottuk le. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az eredeti nyelvén tekintendő a hiteles forrásnak. Kritikus információk esetén javasolt a professzionális emberi fordítás. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.