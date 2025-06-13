<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc3ae5af5973160abba9976cb5a4704c",
  "translation_date": "2025-06-13T11:35:21+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "hu"
}
-->
Nagyszerű, a következő lépésként soroljuk fel a szerver képességeit.

### -2 Szerver képességeinek listázása

Most csatlakozunk a szerverhez, és lekérdezzük annak képességeit:

### -3- A szerver képességeinek átalakítása LLM eszközökké

A szerver képességeinek listázása után a következő lépés, hogy átalakítsuk őket egy olyan formátumba, amit az LLM megért. Miután ez megtörtént, ezek a képességek eszközként szolgálhatnak az LLM számára.

Nagyszerű, most, hogy készen állunk a felhasználói kérések kezelésére, nézzük meg, hogyan valósíthatjuk ezt meg.

### -4- Felhasználói prompt kérés kezelése

Ebben a kódrészletben a felhasználói kéréseket fogjuk kezelni.

Nagyszerű, sikerült!

## Feladat

Vedd át a gyakorlatban írt kódot, és bővítsd ki a szervert további eszközökkel. Ezután hozz létre egy LLM-mel rendelkező klienst, mint a gyakorlatban, és teszteld különböző promptokkal, hogy megbizonyosodj róla, minden szervereszköz dinamikusan meghívódik. Ez a kliensépítési mód nagyszerű felhasználói élményt nyújt, hiszen a végfelhasználók promptokat használhatnak a pontos kliensparancsok helyett, és nem kell tudomásuk legyen az MCP szerver hívásáról.

## Megoldás

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Főbb tanulságok

- Egy LLM hozzáadása a kliensedhez jobb felhasználói interakciót tesz lehetővé az MCP szerverekkel.
- Az MCP szerver válaszát át kell alakítani olyan formátumra, amit az LLM megért.

## Példák

- [Java Számológép](../samples/java/calculator/README.md)
- [.Net Számológép](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Számológép](../samples/javascript/README.md)
- [TypeScript Számológép](../samples/typescript/README.md)
- [Python Számológép](../../../../03-GettingStarted/samples/python)

## További források

## Mi következik

- Következő: [Szerver használata Visual Studio Code segítségével](/03-GettingStarted/04-vscode/README.md)

**Nyilatkozat**:  
Ezt a dokumentumot az AI fordító szolgáltatás [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordítottuk le. Bár igyekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások tartalmazhatnak hibákat vagy pontatlanságokat. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén professzionális emberi fordítást javaslunk. Nem vállalunk felelősséget az ebből a fordításból eredő félreértésekért vagy téves értelmezésekért.