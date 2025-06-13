<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3dd2f1e39277c31b0e57e29d165354d6",
  "translation_date": "2025-06-13T00:50:54+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "hu"
}
-->
Most már, hogy egy kicsit többet tudunk az SSE-ről, építsünk egy SSE szervert.

## Gyakorlat: SSE szerver létrehozása

A szerver létrehozásához két dolgot kell szem előtt tartanunk:

- Webszervert kell használnunk az endpointok megnyitásához a kapcsolat és az üzenetek kezelésére.
- A szervert ugyanúgy építjük fel, ahogy korábban a stdio használatával tettük, eszközökkel, erőforrásokkal és promptokkal.

### -1- Szerver példány létrehozása

A szerver létrehozásához ugyanazokat a típusokat használjuk, mint stdio esetén. Azonban a transport típusnál az SSE-t kell választanunk.

### -2- Útvonalak hozzáadása

Adjunk hozzá útvonalakat, amelyek kezelik a kapcsolatot és a bejövő üzeneteket:

### -3- Szerver képességek hozzáadása

Most, hogy minden SSE-specifikus dolgot definiáltunk, adjunk hozzá szerver képességeket, mint például eszközök, promptok és erőforrások.

A teljes kódod így fog kinézni:

Remek, van egy SSE-t használó szerverünk, nézzük meg, hogyan működik.

## Gyakorlat: SSE szerver hibakeresése Inspectorral

Az Inspector egy remek eszköz, amit egy korábbi leckében már láttunk [Első szerver létrehozása](/03-GettingStarted/01-first-server/README.md). Nézzük meg, hogy itt is használható-e:

### -1- Az Inspector futtatása

Az Inspector futtatásához először futnia kell az SSE szervernek, tehát indítsuk el:

1. Indítsuk el a szervert

1. Indítsuk el az Inspectort

    > ![NOTE]
    > Ezt egy külön terminál ablakban futtasd, mint ahol a szerver fut. Figyelj arra is, hogy az alábbi parancsot igazítsd a szervered URL-jéhez.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

Az Inspector futtatása minden környezetben hasonló. Figyeld meg, hogy ahelyett, hogy a szerver elérési útját és indító parancsát adnánk meg, itt a szerver futási URL-jét adjuk meg, és megadjuk a `/sse` útvonalat is.

### -2- Az eszköz kipróbálása

Csatlakozz a szerverhez az SSE kiválasztásával a legördülő menüből, majd írd be a szerver URL-jét, például http://localhost:4321/sse. Ezután kattints a "Connect" gombra. Ahogy korábban, válaszd ki az eszközök listázását, válassz egy eszközt, és adj meg bemeneti értékeket. Egy hasonló eredményt kell látnod:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.hu.png)

Szuper, működik az Inspector, nézzük meg, hogyan dolgozhatunk Visual Studio Code-dal.

## Feladat

Próbáld meg bővíteni a szervered több képességgel. Nézd meg például ezt az oldalt [https://api.chucknorris.io/](https://api.chucknorris.io/), hogy hozzáadj egy olyan eszközt, amely egy API-t hív meg. Te döntöd el, hogyan nézzen ki a szerver. Jó szórakozást :)

## Megoldás

[Megoldás](./solution/README.md) Itt egy lehetséges megoldás működő kóddal.

## Főbb tanulságok

A fejezet fő tanulságai:

- Az SSE a második támogatott transport típus a stdio mellett.
- Az SSE támogatásához kezelni kell a bejövő kapcsolatokat és üzeneteket egy webes keretrendszer segítségével.
- Az SSE szerver fogyasztásához használhatod az Inspectort és a Visual Studio Code-ot is, ugyanúgy, mint a stdio szerverek esetén. Figyeld meg, hogy az SSE és stdio között van némi különbség: SSE esetén külön kell indítani a szervert, majd utána futtatni az Inspector eszközt, ahol meg kell adni az URL-t.

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

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások tartalmazhatnak hibákat vagy pontatlanságokat. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy félreértelmezésekért.