<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d90ca3d326c48fab2ac0ebd3a9876f59",
  "translation_date": "2025-07-13T20:00:24+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "hu"
}
-->
Most, hogy már többet tudunk az SSE-ről, építsünk egy SSE szervert.

## Gyakorlat: SSE szerver létrehozása

A szerver létrehozásakor két dolgot kell szem előtt tartanunk:

- Webszervert kell használnunk, hogy elérhetővé tegyük a kapcsolat és az üzenetek végpontjait.
- A szervert úgy építsük fel, ahogy azt stdio használatakor tettük, eszközökkel, erőforrásokkal és promptokkal.

### -1- Szerver példány létrehozása

A szerver létrehozásához ugyanazokat a típusokat használjuk, mint stdio esetén. Azonban a transzportnál az SSE-t kell választanunk.

Most adjuk hozzá a szükséges útvonalakat.

### -2- Útvonalak hozzáadása

Adjunk hozzá útvonalakat, amelyek kezelik a kapcsolatot és a bejövő üzeneteket:

Most adjunk hozzá képességeket a szerverhez.

### -3- Szerver képességek hozzáadása

Most, hogy minden SSE-specifikus dolgot definiáltunk, adjunk hozzá szerver képességeket, mint például eszközök, promptok és erőforrások.

A teljes kódod így kell kinézzen:

Remek, van egy SSE-t használó szerverünk, nézzük meg, hogyan működik.

## Gyakorlat: SSE szerver hibakeresése Inspectorral

Az Inspector egy nagyszerű eszköz, amit az előző leckében láttunk [Első szerver létrehozása](/03-GettingStarted/01-first-server/README.md). Nézzük meg, használhatjuk-e itt is az Inspectort:

### -1- Az Inspector futtatása

Az Inspector futtatásához először egy SSE szervernek kell futnia, tehát indítsuk el azt:

1. Indítsd el a szervert

1. Indítsd el az Inspectort

    > ![NOTE]
    > Ezt egy külön terminál ablakban futtasd, mint ahol a szerver fut. Ne feledd, az alábbi parancsot módosítanod kell, hogy illeszkedjen a szervered URL-jéhez.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Az Inspector futtatása minden környezetben ugyanúgy néz ki. Figyeld meg, hogy ahelyett, hogy a szerver elindításához egy elérési utat és parancsot adnánk meg, itt az URL-t adjuk meg, ahol a szerver fut, és megadjuk a `/sse` útvonalat.

### -2- Az eszköz kipróbálása

Csatlakozz a szerverhez az SSE kiválasztásával a legördülő listából, és írd be a szervered URL-jét, például http://localhost:4321/sse. Ezután kattints a "Connect" gombra. Ahogy korábban, válaszd ki az eszközök listázását, válassz egy eszközt, és adj meg bemeneti értékeket. Az eredmény valahogy így fog kinézni:

![SSE szerver fut az Inspectorban](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.hu.png)

Remek, sikeresen használod az Inspectort, nézzük meg, hogyan dolgozhatsz Visual Studio Code-dal.

## Feladat

Próbáld meg bővíteni a szervered több képességgel. Nézd meg [ezt az oldalt](https://api.chucknorris.io/), hogy például hozzáadj egy eszközt, ami egy API-t hív meg. Te döntöd el, hogyan nézzen ki a szerver. Jó szórakozást :)

## Megoldás

[Megoldás](./solution/README.md) Itt egy lehetséges megoldás működő kóddal.

## Főbb tanulságok

A fejezet főbb tanulságai a következők:

- Az SSE a második támogatott transzport a stdio mellett.
- Az SSE támogatásához kezelni kell a bejövő kapcsolatokat és üzeneteket egy webes keretrendszer segítségével.
- Az SSE szerver fogyasztásához használhatod az Inspectort és a Visual Studio Code-ot is, akárcsak a stdio szervereknél. Figyeld meg, hogy a stdio és az SSE között van némi különbség: SSE esetén külön kell indítani a szervert, majd az Inspector eszközt. Az Inspector esetén meg kell adni az URL-t is.

## Minták

- [Java számológép](../samples/java/calculator/README.md)
- [.Net számológép](../../../../03-GettingStarted/samples/csharp)
- [JavaScript számológép](../samples/javascript/README.md)
- [TypeScript számológép](../samples/typescript/README.md)
- [Python számológép](../../../../03-GettingStarted/samples/python)

## További források

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Mi következik

- Következő: [HTTP Streaming MCP-vel (Streamable HTTP)](../06-http-streaming/README.md)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.