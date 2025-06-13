<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "64645691bf0985f1760b948123edf269",
  "translation_date": "2025-06-13T10:56:13+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "hu"
}
-->
Most már, hogy többet tudunk az SSE-ről, építsünk egy SSE szervert.

## Gyakorlat: SSE szerver létrehozása

A szerver létrehozásához két dolgot kell szem előtt tartanunk:

- Webszervert kell használnunk, hogy elérhetővé tegyük a kapcsolat és az üzenetek végpontjait.
- A szervert ugyanúgy kell felépítenünk, mint stdio használata esetén, eszközökkel, erőforrásokkal és promptokkal.

### -1- Szerver példány létrehozása

A szerver létrehozásához ugyanazokat a típusokat használjuk, mint stdio esetén. Azonban a transportnál az SSE-t kell választanunk.

### -2- Útvonalak hozzáadása

Adjunk hozzá útvonalakat, amelyek kezelik a kapcsolatot és a bejövő üzeneteket:

### -3- Szerver képességek hozzáadása

Most, hogy minden SSE-specifikus elemet definiáltunk, adjunk hozzá szerver képességeket, mint eszközök, promptok és erőforrások.

Teljes kódod így nézzen ki:

Nagyszerű, van egy SSE-t használó szerverünk, próbáljuk ki!

## Gyakorlat: SSE szerver hibakeresése Inspectorral

Az Inspector egy remek eszköz, amit már láttunk az előző leckében [Creating your first server](/03-GettingStarted/01-first-server/README.md). Nézzük meg, használhatjuk-e itt is:

### -1- Inspector futtatása

Az Inspector futtatásához először egy futó SSE szerver kell, tehát indítsuk el:

1. Indítsd el a szervert

1. Indítsd el az Inspectort

    > ![NOTE]
    > Ezt egy külön terminál ablakban futtasd, mint ahol a szerver fut. Ne feledd, a parancsot igazítanod kell a szervered URL-jéhez.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

Az Inspector futtatása minden futtatókörnyezetben ugyanúgy néz ki. Figyeld meg, hogy ahelyett, hogy a szerver indításához útvonalat és parancsot adnánk meg, itt az URL-t adjuk meg, ahol a szerver fut, és megadjuk az `/sse` útvonalat is.

### -2- Az eszköz kipróbálása

Csatlakozz a szerverhez az SSE kiválasztásával a legördülő menüből, és írd be a szerver URL-jét, például http://localhost:4321/sse. Ezután kattints a "Connect" gombra. Ahogy korábban, válassz eszközt, adj meg bemeneti értékeket, és látnod kell egy hasonló eredményt:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.hu.png)

Remek, működik az Inspectorral, nézzük meg, hogyan dolgozhatunk Visual Studio Code-dal.

## Feladat

Próbáld meg bővíteni a szervered több képességgel. Nézd meg [ezt az oldalt](https://api.chucknorris.io/), például adj hozzá egy olyan eszközt, ami egy API-t hív meg, te döntöd el, hogyan nézzen ki a szerver. Jó szórakozást :)

## Megoldás

[Megoldás](./solution/README.md) Íme egy lehetséges megoldás működő kóddal.

## Főbb tanulságok

A fejezet főbb tanulságai:

- Az SSE a második támogatott transport a stdio mellett.
- Az SSE támogatásához kezelned kell a bejövő kapcsolatokat és üzeneteket egy webkeretrendszerrel.
- Az SSE szervert mind az Inspectorral, mind a Visual Studio Code-dal használhatod, akárcsak a stdio szervereket. Figyeld meg a különbségeket: SSE esetén külön kell indítani a szervert, majd az Inspector eszközt. Az Inspectornál meg kell adni az URL-t is.

## Minták

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## További források

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Mi következik

- Következő: [HTTP Streaming MCP-vel (Streamable HTTP)](/03-GettingStarted/06-http-streaming/README.md)

**Nyilatkozat:**  
Ezt a dokumentumot az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordítottuk le. Bár igyekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén professzionális emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.