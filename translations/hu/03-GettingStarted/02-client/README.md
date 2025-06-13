<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a0acf3093691b1cfcc008a8c6648ea26",
  "translation_date": "2025-06-13T06:51:21+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "hu"
}
-->
A fenti kódban:

- Importáltuk a könyvtárakat
- Létrehoztunk egy kliens példányt, és stdio segítségével csatlakoztattuk a szállításhoz.
- Felsoroltuk a promptokat, erőforrásokat és eszközöket, majd mindet meghívtuk.

Így tehát van egy kliensünk, amely képes kommunikálni egy MCP szerverrel.

Most a következő gyakorlati részben lépésről lépésre átvesszük az egyes kódrészleteket, és elmagyarázzuk, mi történik pontosan.

## Gyakorlat: Kliens írása

Ahogy fent említettük, szánjunk időt a kód magyarázatára, és természetesen nyugodtan kódolj is velünk.

### -1- Könyvtárak importálása

Importáljuk a szükséges könyvtárakat, szükségünk lesz hivatkozásokra a klienshez és a választott szállítási protokollhoz, ami jelen esetben stdio. Az stdio egy olyan protokoll, ami helyi gépen futó folyamatokhoz való. Az SSE egy másik szállítási protokoll, amit a későbbi fejezetekben mutatunk be, ez a másik lehetőséged. Most azonban folytassuk az stdio-val.

Haladjunk tovább az példányosításhoz.

### -2- Kliens és szállítás példányosítása

Létre kell hoznunk egy példányt a szállításból, és egyet a kliensből: 

### -3- A szerver funkcióinak listázása

Most már van egy kliensünk, ami csatlakozni tud, ha a programot futtatjuk. Azonban még nem listázza a funkcióit, ezt most pótoljuk:

Remek, most már megkaptuk az összes funkciót. De mikor használjuk ezeket? Ez a kliens elég egyszerű, ami azt jelenti, hogy explicit módon kell meghívnunk a funkciókat, amikor szükségünk van rájuk. A következő fejezetben egy fejlettebb klienst fogunk létrehozni, amely saját nagy nyelvi modellel (LLM) rendelkezik. Addig nézzük meg, hogyan hívhatjuk meg a szerver funkcióit:

### -4- Funkciók meghívása

A funkciók meghívásához meg kell győződnünk arról, hogy a megfelelő argumentumokat adjuk meg, és bizonyos esetekben a meghívni kívánt elem nevét is.

### -5- A kliens futtatása

A kliens futtatásához írd be a következő parancsot a terminálba:

## Feladat

Ebben a feladatban a tanultak alapján készítsd el saját kliensedet.

Itt egy szerver, amit használhatsz, és amelyhez a kliensed kódján keresztül kell csatlakoznod. Próbálj meg több funkciót hozzáadni a szerverhez, hogy érdekesebbé tedd.

## Megoldás

[Solution](./solution/README.md)

## Főbb tanulságok

A fejezet főbb tanulságai a kliensekről:

- Használhatók a szerver funkcióinak felfedezésére és meghívására egyaránt.
- Elindíthatnak egy szervert, miközben maguk is elindulnak (ahogy ebben a fejezetben), de a kliensek futó szerverekhez is csatlakozhatnak.
- Remek módja a szerver képességeinek tesztelésére, alternatívaként az Inspectorhoz, ahogy az előző fejezetben bemutattuk.

## További források

- [Kliens építése MCP-ben](https://modelcontextprotocol.io/quickstart/client)

## Minták

- [Java Számológép](../samples/java/calculator/README.md)
- [.Net Számológép](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Számológép](../samples/javascript/README.md)
- [TypeScript Számológép](../samples/typescript/README.md)
- [Python Számológép](../../../../03-GettingStarted/samples/python)

## Mi következik

- Következő: [Kliens létrehozása LLM-mel](/03-GettingStarted/03-llm-client/README.md)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár igyekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum anyanyelvű változatát kell tekinteni a hiteles forrásnak. Kritikus információk esetén szakmai emberi fordítást javaslunk. Nem vállalunk felelősséget az ebből eredő félreértésekért vagy téves értelmezésekért.