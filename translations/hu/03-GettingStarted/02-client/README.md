<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2342baa570312086fc19edcf41320250",
  "translation_date": "2025-06-17T16:07:12+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "hu"
}
-->
A korábbi kódban:

- Importáltuk a könyvtárakat
- Létrehoztunk egy kliens példányt, és stdio-val csatlakoztattuk a transzporthoz.
- Felsoroltuk a promptokat, erőforrásokat és eszközöket, majd mindet meghívtuk.

Így tehát kész is van egy kliens, amely képes kommunikálni egy MCP szerverrel.

A következő gyakorlati részben szánjunk időt arra, hogy részletesen átbeszéljük a kódrészleteket, és magyarázzuk el, mi történik.

## Gyakorlat: Kliens írása

Ahogy fent említettük, most alaposan magyarázzuk el a kódot, és nyugodtan kövesd a példát lépésről lépésre.

### -1- Könyvtárak importálása

Importáljuk azokat a könyvtárakat, amelyekre szükségünk lesz, nevezetesen a kliens és a választott transzport protokoll, az stdio hivatkozásait. Az stdio olyan protokoll, amely helyi gépen futó programokhoz készült. Az SSE egy másik transzport protokoll, amit a későbbi fejezetekben mutatunk be, de most maradjunk az stdio-nál.

Most pedig lépjünk tovább az példányosításhoz.

### -2- Kliens és transzport példányosítása

Létre kell hoznunk egy példányt a transzportból, és egyet a kliensből is:

### -3- A szerver funkcióinak listázása

Most már van egy kliensünk, amely csatlakozni tud, ha a program elindul. Azonban még nem listázza a szerver funkcióit, ezért ezt tegyük meg most:

Nagyszerű, most már lekaptuk az összes funkciót. De mikor használjuk őket? Ez a kliens elég egyszerű, ami azt jelenti, hogy explicit módon kell meghívnunk a funkciókat, amikor szükségünk van rájuk. A következő fejezetben egy fejlettebb klienst készítünk, amely saját nagy nyelvi modellhez (LLM) fér hozzá. Most azonban nézzük meg, hogyan hívhatjuk meg a szerver funkcióit:

### -4- Funkciók meghívása

Ahhoz, hogy meghívjuk a funkciókat, meg kell győződnünk arról, hogy a megfelelő argumentumokat adjuk meg, és bizonyos esetekben a meghívni kívánt funkció nevét is.

### -5- A kliens futtatása

A kliens futtatásához írd be a következő parancsot a terminálba:

## Feladat

Ebben a feladatban a kliens írás során tanultakat alkalmazva hozz létre egy saját klienst.

Itt van egy szerver, amelyet a kliens kódodon keresztül kell hívnod, próbálj meg több funkciót hozzáadni a szerverhez, hogy érdekesebbé tedd.

## Megoldás

[Solution](./solution/README.md)

## Főbb tanulságok

A fejezet legfontosabb tanulságai a kliensekkel kapcsolatban:

- Használhatók a szerver funkcióinak felfedezésére és meghívására is.
- Indíthatnak szervert, miközben maguk is elindulnak (ahogy ebben a fejezetben), de kliensek csatlakozhatnak már futó szerverekhez is.
- Kiváló módja a szerver képességeinek tesztelésére, alternatívaként az Inspectorhoz képest, ahogy az előző fejezetben bemutattuk.

## További források

- [Ügyfelek építése MCP-ben](https://modelcontextprotocol.io/quickstart/client)

## Példák

- [Java Számológép](../samples/java/calculator/README.md)
- [.Net Számológép](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Számológép](../samples/javascript/README.md)
- [TypeScript Számológép](../samples/typescript/README.md)
- [Python Számológép](../../../../03-GettingStarted/samples/python)

## Mi következik?

- Következő: [Kliens létrehozása LLM-mel](/03-GettingStarted/03-llm-client/README.md)

**Felelősségkizárás**:  
Ezt a dokumentumot az AI fordító szolgáltatás [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordítottuk le. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy félreértelmezésekért.