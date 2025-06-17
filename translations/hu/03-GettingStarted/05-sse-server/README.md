<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1681ca3633aeb49ee03766abdbb94a93",
  "translation_date": "2025-06-17T22:25:16+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "hu"
}
-->
Most, hogy már többet tudunk az SSE-ről, építsünk egy SSE szervert.

## Gyakorlat: SSE szerver létrehozása

A szerver elkészítéséhez két dolgot kell szem előtt tartanunk:

- Webszervert kell használnunk, hogy végpontokat tegyünk elérhetővé a kapcsolat és az üzenetek kezelésére.
- A szervert ugyanúgy építjük fel, mint korábban stdio használatakor, eszközökkel, erőforrásokkal és promptokkal.

### -1- Szerver példány létrehozása

A szerver létrehozásához ugyanazokat a típusokat használjuk, mint stdio esetén. Azonban a transport típusa legyen SSE.

---

Most adjuk hozzá a szükséges útvonalakat.

### -2- Útvonalak hozzáadása

Adjunk hozzá olyan útvonalakat, amelyek kezelik a kapcsolatot és a bejövő üzeneteket:

---

Most adjunk képességeket a szerverhez.

### -3- Szerver képességek hozzáadása

Miután definiáltuk az SSE-specifikus elemeket, adjunk hozzá szerver képességeket, mint például eszközök, promptok és erőforrások.

---

A teljes kód így nézzen ki:

---

Szuper, van egy SSE-t használó szerverünk, próbáljuk ki most.

## Gyakorlat: SSE szerver hibakeresése az Inspectorral

Az Inspector egy nagyszerű eszköz, amit az előző leckében már láttunk [Első szerver létrehozása](/03-GettingStarted/01-first-server/README.md). Nézzük meg, hogy itt is használhatjuk-e:

### -1- Inspector futtatása

Az Inspector futtatásához először futtatnunk kell egy SSE szervert, tegyük meg most:

1. Indítsd el a szervert

---

1. Indítsd el az Inspectort

    > ![NOTE]
    > Ezt egy külön terminál ablakban futtasd, mint ahol a szerver fut. Ne feledd, hogy az alábbi parancsot a szervered URL-jéhez kell igazítani.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Az Inspector futtatása minden futtatókörnyezetben ugyanúgy néz ki. Figyeld meg, hogy ahelyett, hogy egy elérési utat és indító parancsot adnánk meg a szerverhez, itt a szerver URL-jét adjuk meg, és megadjuk a `/sse` útvonalat.

### -2- Az eszköz kipróbálása

Csatlakozz a szerverhez az SSE kiválasztásával a legördülő menüből, és írd be a szervered URL-jét, például http://localhost:4321/sse. Ezután kattints a "Connect" gombra. Ahogy korábban, listázd az eszközöket, válassz egyet, és adj meg bemeneti értékeket. Eredményül valami ilyesmit kell látnod:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.hu.png)

Szuper, működik az Inspector, nézzük meg, hogyan dolgozhatunk Visual Studio Code-dal.

## Feladat

Próbáld meg tovább fejleszteni a szervered több képességgel. Nézd meg például ezt az oldalt: [https://api.chucknorris.io/](https://api.chucknorris.io/), hogy hozzáadj egy eszközt, ami egy API-t hív meg. Te döntöd el, hogyan nézzen ki a szerver. Jó szórakozást :)

## Megoldás

[Megoldás](./solution/README.md) Íme egy lehetséges megoldás működő kóddal.

## Fő tanulságok

A fejezet legfontosabb tanulságai:

- Az SSE a második támogatott transport a stdio mellett.
- Az SSE támogatásához kezelni kell a bejövő kapcsolatokat és üzeneteket egy webes keretrendszer segítségével.
- Az Inspector és a Visual Studio Code egyaránt használható SSE szerver fogyasztására, akárcsak stdio szerverek esetén. Azonban van némi különbség stdio és SSE között: SSE esetén a szervert külön kell elindítani, majd utána futtatni az Inspector eszközt. Az Inspector esetében az URL megadása is szükséges.

## Minták

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## További források

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Mi következik?

- Következő: [HTTP Streaming MCP-vel (Streamable HTTP)](/03-GettingStarted/06-http-streaming/README.md)

**Jogi nyilatkozat**:  
Ezt a dokumentumot az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordítottuk le. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén profi, emberi fordítást javaslunk. Nem vállalunk felelősséget az ebből eredő félreértésekért vagy téves értelmezésekért.