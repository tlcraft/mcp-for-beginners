<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4cc245e2f4ea5db5e2b8c2cd1dadc4b4",
  "translation_date": "2025-07-04T18:30:21+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "hu"
}
-->
A fenti kódban:

- Importáltuk a könyvtárakat
- Létrehoztunk egy kliens példányt, és stdio segítségével csatlakoztattuk a transzporthoz.
- Felsoroltuk a promptokat, erőforrásokat és eszközöket, majd mindet meghívtuk.

Így tehát van egy kliensünk, amely képes kommunikálni egy MCP szerverrel.

A következő gyakorlati részben szánjunk időt arra, hogy részletesen átbeszéljük a kódrészleteket, és magyarázzuk el, mi történik pontosan.

## Gyakorlat: Kliens írása

Ahogy fentebb említettük, szánjunk időt a kód magyarázatára, és természetesen, ha szeretnéd, kódolj velünk együtt.

### -1- Könyvtárak importálása

Importáljuk a szükséges könyvtárakat, szükségünk lesz hivatkozásokra a klienshez és a választott transzport protokollhoz, az stdio-hoz. Az stdio egy olyan protokoll, amely helyi gépen futó alkalmazásokhoz készült. Az SSE egy másik transzport protokoll, amelyet a későbbi fejezetekben mutatunk be, de ez a másik lehetőséged. Egyelőre azonban folytassuk az stdio-val.

Haladjunk tovább az példányosításhoz.

### -2- Kliens és transzport példányosítása

Létre kell hoznunk egy példányt a transzportból, és egyet a kliensből is:

### -3- A szerver funkcióinak listázása

Most már van egy kliensünk, amely képes csatlakozni, ha a programot futtatjuk. Azonban még nem listázza a funkciókat, így ezt most pótoljuk:

Nagyszerű, most már lekaptuk az összes funkciót. De mikor használjuk őket? Nos, ez a kliens elég egyszerű, abban az értelemben, hogy explicit módon kell meghívnunk a funkciókat, amikor szükségünk van rájuk. A következő fejezetben egy fejlettebb klienst fogunk létrehozni, amely saját nagy nyelvi modellhez (LLM) fér hozzá. Egyelőre azonban nézzük meg, hogyan hívhatjuk meg a szerver funkcióit:

### -4- Funkciók meghívása

A funkciók meghívásához biztosítanunk kell, hogy a megfelelő argumentumokat adjuk meg, és bizonyos esetekben a meghívni kívánt funkció nevét is.

### -5- A kliens futtatása

A kliens futtatásához írd be a következő parancsot a terminálba:

## Feladat

Ebben a feladatban a kliens létrehozásával kapcsolatos ismereteidet fogod alkalmazni, és saját klienst készítesz.

Itt van egy szerver, amelyet használhatsz, és amelyet a kliensed kódjából kell meghívnod. Próbálj meg több funkciót hozzáadni a szerverhez, hogy érdekesebbé tedd.

## Megoldás

[Solution](./solution/README.md)

## Főbb tanulságok

A fejezet legfontosabb tanulságai a kliensekkel kapcsolatban:

- Használhatók a szerver funkcióinak felfedezésére és meghívására egyaránt.
- Elindíthatnak egy szervert, miközben maguk is elindulnak (ahogy ebben a fejezetben), de a kliensek csatlakozhatnak már futó szerverekhez is.
- Kiváló módja a szerver képességeinek tesztelésére, alternatívaként az Inspectorhoz, ahogy az előző fejezetben is bemutattuk.

## További források

- [Kliensek építése MCP-ben](https://modelcontextprotocol.io/quickstart/client)

## Minták

- [Java számológép](../samples/java/calculator/README.md)
- [.Net számológép](../../../../03-GettingStarted/samples/csharp)
- [JavaScript számológép](../samples/javascript/README.md)
- [TypeScript számológép](../samples/typescript/README.md)
- [Python számológép](../../../../03-GettingStarted/samples/python)

## Mi következik

- Következő: [Kliens létrehozása LLM-mel](../03-llm-client/README.md)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.