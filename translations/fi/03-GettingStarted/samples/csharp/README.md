<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "882aae00f1d3f007e20d03b883f44afa",
  "translation_date": "2025-06-18T06:01:57+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "fi"
}
-->
# Peruslaskin MCP-palvelu

Tämä palvelu tarjoaa peruslaskutoimituksia Model Context Protocolin (MCP) kautta. Se on suunniteltu yksinkertaiseksi esimerkiksi aloittelijoille, jotka opettelevat MCP:n toteutuksia.

Lisätietoja löytyy [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) -sivulta.

## Ominaisuudet

Tämä laskinpalvelu tarjoaa seuraavat toiminnot:

1. **Peruslaskutoimitukset**:
   - Kahden luvun yhteenlasku
   - Yhden luvun vähentäminen toisesta
   - Kahden luvun kertolasku
   - Yhden luvun jakaminen toisella (nollalla jakamisen tarkistus)

## Käyttö `stdio` -tyypin kanssa

## Konfigurointi

1. **Määritä MCP-palvelimet**:
   - Avaa työtilasi VS Codessa.
   - Luo `.vscode/mcp.json` -tiedosto työtilakansioosi MCP-palvelimien määrittämistä varten. Esimerkkikonfiguraatio:

     ```jsonc
     {
       "inputs": [
         {
           "type": "promptString",
           "id": "repository-root",
           "description": "The absolute path to the repository root"
         }
       ],
       "servers": {
         "calculator-mcp-dotnet": {
           "type": "stdio",
           "command": "dotnet",
           "args": [
             "run",
             "--project",
             "${input:repository-root}/03-GettingStarted/samples/csharp/src/calculator.csproj"
           ]
         }
       }
     }
     ```

   - Sinulta kysytään GitHub-repositorion juurihakemistoa, jonka saat komennolla `git rev-parse --show-toplevel`.

## Using the Service

The service exposes the following API endpoints through the MCP protocol:

- `add(a, b)`: Add two numbers together
- `subtract(a, b)`: Subtract the second number from the first
- `multiply(a, b)`: Multiply two numbers
- `divide(a, b)`: Divide the first number by the second (with zero check)
- isPrime(n): Check if a number is prime

## Test with Github Copilot Chat in VS Code

1. Try making a request to the service using the MCP protocol. For example, you can ask:
   - "Add 5 and 3"
   - "Subtract 10 from 4"
   - "Multiply 6 and 7"
   - "Divide 8 by 2"
   - "Does 37854 prime?"
   - "What are the 3 prime numbers before after 4242?"
2. To make sure it's using the tools add #MyCalculator to the prompt. For example:
   - "Add 5 and 3 #MyCalculator"
   - "Subtract 10 from 4 #MyCalculator


## Containerized Version

The previous soultion is great when you have the .NET SDK installed, and all the dependencies are in place. However, if you would like to share the solution or run it in a different environment, you can use the containerized version.

1. Start Docker and make sure it's running.
1. From a terminal, navigate in the folder `03-GettingStarted\samples\csharp\src` 
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` korvaten oman Docker Hub -käyttäjänimesi):
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. Kun kuva on rakennettu, ladataan se Docker Hubiin. Suorita seuraava komento:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Käytä Docker-versiota

1. Korvaa palvelinmääritykset `.vscode/mcp.json` -tiedostossa seuraavasti:
   ```json
    "mcp-calc": {
      "command": "docker",
      "args": [
        "run",
        "--rm",
        "-i",
        "<YOUR-DOCKER-USERNAME>/mcp-calc"
      ],
      "envFile": "",
      "env": {}
    }
   ```
   Konfiguraatiosta näet, että komento on `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {`, ja kuten aiemmin, voit pyytää laskinpalvelua tekemään laskutoimituksia puolestasi.

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, otathan huomioon, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäinen asiakirja sen alkuperäiskielellä on katsottava viralliseksi lähteeksi. Tärkeiden tietojen osalta suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä johtuvista väärinymmärryksistä tai tulkinnoista.