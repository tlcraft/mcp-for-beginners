<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e5ea5e7582f70008ea9bec3b3820f20a",
  "translation_date": "2025-05-17T14:31:46+00:00",
  "source_file": "04-PracticalImplementation/samples/java/containerapp/README.md",
  "language_code": "ro"
}
-->
## Arhitectura Sistemului

Acest proiect demonstrează o aplicație web care utilizează verificarea siguranței conținutului înainte de a trimite cererile utilizatorului către un serviciu de calculator prin Protocolul de Context al Modelului (MCP).

### Cum Funcționează

1. **Introducerea Utilizatorului**: Utilizatorul introduce o cerere de calcul în interfața web
2. **Verificarea Siguranței Conținutului (Intrare)**: Cererea este analizată de API-ul Azure Content Safety
3. **Decizia de Siguranță (Intrare)**:
   - Dacă conținutul este sigur (severitate < 2 în toate categoriile), se continuă către calculator
   - Dacă conținutul este marcat ca potențial dăunător, procesul se oprește și se returnează un avertisment
4. **Integrarea Calculatorului**: Conținutul sigur este procesat de LangChain4j, care comunică cu serverul MCP al calculatorului
5. **Verificarea Siguranței Conținutului (Ieșire)**: Răspunsul botului este analizat de API-ul Azure Content Safety
6. **Decizia de Siguranță (Ieșire)**:
   - Dacă răspunsul botului este sigur, este afișat utilizatorului
   - Dacă răspunsul botului este marcat ca potențial dăunător, este înlocuit cu un avertisment
7. **Răspuns**: Rezultatele (dacă sunt sigure) sunt afișate utilizatorului împreună cu ambele analize de siguranță

## Utilizarea Protocolului de Context al Modelului (MCP) cu Servicii de Calculator

Acest proiect demonstrează cum să folosești Protocolul de Context al Modelului (MCP) pentru a apela serviciile MCP ale calculatorului din LangChain4j. Implementarea folosește un server MCP local care rulează pe portul 8080 pentru a oferi operații de calculator.

### Configurarea Serviciului de Siguranță a Conținutului Azure

Înainte de a utiliza funcțiile de siguranță a conținutului, trebuie să creezi o resursă de serviciu Azure Content Safety:

1. Autentifică-te în [Azure Portal](https://portal.azure.com)
2. Click pe "Create a resource" și caută "Content Safety"
3. Selectează "Content Safety" și click pe "Create"
4. Introdu un nume unic pentru resursa ta
5. Selectează abonamentul și grupul de resurse (sau creează unul nou)
6. Alege o regiune suportată (verifică [Region availability](https://azure.microsoft.com/en-us/global-infrastructure/services/?products=cognitive-services) pentru detalii)
7. Selectează un nivel de preț corespunzător
8. Click pe "Create" pentru a implementa resursa
9. Odată ce implementarea este completă, click pe "Go to resource"
10. În panoul din stânga, sub "Resource Management", selectează "Keys and Endpoint"
11. Copiază oricare dintre chei și URL-ul endpoint pentru utilizare în pasul următor

### Configurarea Variabilelor de Mediu

Setează variabila de mediu `GITHUB_TOKEN` pentru autentificarea modelelor GitHub:
```sh
export GITHUB_TOKEN=<your_github_token>
```

Pentru funcțiile de siguranță a conținutului, setează:
```sh
export CONTENT_SAFETY_ENDPOINT=<your_content_safety_endpoint>
export CONTENT_SAFETY_KEY=<your_content_safety_key>
```

Aceste variabile de mediu sunt utilizate de aplicație pentru a se autentifica cu serviciul Azure Content Safety. Dacă aceste variabile nu sunt setate, aplicația va folosi valori de rezervă pentru scopuri demonstrative, dar funcțiile de siguranță a conținutului nu vor funcționa corect.

### Pornirea Serverului Calculator MCP

Înainte de a rula clientul, trebuie să pornești serverul calculator MCP în modul SSE pe localhost:8080.

## Descrierea Proiectului

Acest proiect demonstrează integrarea Protocolului de Context al Modelului (MCP) cu LangChain4j pentru a apela servicii de calculator. Caracteristicile cheie includ:

- Utilizarea MCP pentru a se conecta la un serviciu de calculator pentru operațiuni matematice de bază
- Verificarea siguranței conținutului în două straturi, atât pentru cererile utilizatorului cât și pentru răspunsurile botului
- Integrarea cu modelul gpt-4.1-nano al GitHub prin LangChain4j
- Utilizarea Server-Sent Events (SSE) pentru transportul MCP

## Integrarea Siguranței Conținutului

Proiectul include funcții de siguranță a conținutului cuprinzătoare pentru a asigura că atât intrările utilizatorului cât și răspunsurile sistemului sunt lipsite de conținut dăunător:

1. **Verificarea Intrării**: Toate cererile utilizatorului sunt analizate pentru categorii de conținut dăunător, cum ar fi discursul de ură, violența, auto-vătămarea și conținutul sexual înainte de procesare.

2. **Verificarea Ieșirii**: Chiar și atunci când se utilizează modele potențial necenzurate, sistemul verifică toate răspunsurile generate prin aceleași filtre de siguranță a conținutului înainte de a le afișa utilizatorului.

Această abordare în două straturi asigură că sistemul rămâne sigur indiferent de modelul AI utilizat, protejând utilizatorii atât de intrări dăunătoare cât și de ieșiri potențial problematice generate de AI.

## Clientul Web

Aplicația include o interfață web prietenoasă care permite utilizatorilor să interacționeze cu sistemul de Calculator Siguranță Conținut:

### Caracteristicile Interfeței Web

- Formular simplu și intuitiv pentru introducerea cererilor de calcul
- Validare de siguranță a conținutului în două straturi (intrare și ieșire)
- Feedback în timp real asupra siguranței cererii și răspunsului
- Indicatori de siguranță colorați pentru interpretare ușoară
- Design curat și receptiv care funcționează pe diverse dispozitive
- Exemple de cereri sigure pentru a ghida utilizatorii

### Utilizarea Clientului Web

1. Pornește aplicația:
   ```sh
   mvn spring-boot:run
   ```

2. Deschide browserul și navighează la `http://localhost:8087`

3. Introdu o cerere de calcul în zona de text furnizată (de exemplu, "Calculează suma dintre 24.5 și 17.3")

4. Click pe "Submit" pentru a procesa cererea ta

5. Vizualizează rezultatele, care vor include:
   - Analiza siguranței conținutului cererii tale
   - Rezultatul calculat (dacă cererea a fost sigură)
   - Analiza siguranței conținutului răspunsului botului
   - Orice avertismente de siguranță dacă fie intrarea sau ieșirea a fost marcată

Clientul web gestionează automat ambele procese de verificare a siguranței conținutului, asigurându-se că toate interacțiunile sunt sigure și corespunzătoare indiferent de modelul AI utilizat.

**Declinare:**
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim să obținem acuratețea, vă rugăm să fiți conștienți de faptul că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa maternă ar trebui considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională umană. Nu suntem responsabili pentru niciun fel de neînțelegeri sau interpretări greșite care pot apărea din utilizarea acestei traduceri.