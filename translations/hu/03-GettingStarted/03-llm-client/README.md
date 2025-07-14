<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f74887f51a69d3f255cb83d0b517c623",
  "translation_date": "2025-07-13T18:55:17+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "hu"
}
-->
Nagyszerű, a következő lépésként soroljuk fel a szerver képességeit.

### -2 Szerver képességeinek listázása

Most csatlakozunk a szerverhez, és lekérdezzük a képességeit:

### -3- A szerver képességeinek átalakítása LLM eszközökké

A szerver képességeinek listázása után a következő lépés, hogy olyan formátumba alakítsuk őket, amelyet az LLM megért. Miután ez megtörtént, ezeket a képességeket eszközként adhatjuk át az LLM-nek.

Nagyszerű, most, hogy készen állunk a felhasználói kérések kezelésére, lássunk neki.

### -4- Felhasználói prompt kérés kezelése

Ebben a kódrészletben a felhasználói kéréseket fogjuk kezelni.

Nagyszerű, sikerült!

## Feladat

Vedd át a gyakorlatban használt kódot, és bővítsd ki a szervert további eszközökkel. Ezután hozz létre egy klienst LLM-mel, ahogy a gyakorlatban is tettük, és teszteld különböző promptokkal, hogy megbizonyosodj arról, hogy a szerver összes eszköze dinamikusan meghívásra kerül. Ez a kliensépítési mód nagyszerű felhasználói élményt nyújt, hiszen a felhasználók promptokat használhatnak a pontos kliensparancsok helyett, és nem kell tudniuk arról, hogy egy MCP szerver hívódik meg.

## Megoldás

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Főbb tanulságok

- Az LLM hozzáadása a klienshez jobb felhasználói interakciót tesz lehetővé az MCP szerverekkel.
- Az MCP szerver válaszát olyan formátumba kell alakítani, amelyet az LLM megért.

## Minták

- [Java számológép](../samples/java/calculator/README.md)
- [.Net számológép](../../../../03-GettingStarted/samples/csharp)
- [JavaScript számológép](../samples/javascript/README.md)
- [TypeScript számológép](../samples/typescript/README.md)
- [Python számológép](../../../../03-GettingStarted/samples/python)

## További források

## Mi következik

- Következő: [Szerver használata Visual Studio Code-dal](../04-vscode/README.md)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.