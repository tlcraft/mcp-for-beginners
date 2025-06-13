<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "195f7287638b77a549acadd96c8f981c",
  "translation_date": "2025-06-13T01:16:49+00:00",
  "source_file": "05-AdvancedTopics/mcp-realtimestreaming/README.md",
  "language_code": "sr"
}
-->
# Model Context Protocol za streaming podataka u realnom vremenu

## Pregled

Streaming podataka u realnom vremenu postao je neophodan u današnjem svetu vođenom podacima, gde firme i aplikacije zahtevaju trenutni pristup informacijama kako bi donosile pravovremene odluke. Model Context Protocol (MCP) predstavlja značajan napredak u optimizaciji ovih procesa streaminga u realnom vremenu, poboljšavajući efikasnost obrade podataka, održavajući kontekstualni integritet i unapređujući ukupne performanse sistema.

Ovaj modul istražuje kako MCP transformiše streaming podataka u realnom vremenu pružajući standardizovan pristup upravljanju kontekstom između AI modela, streaming platformi i aplikacija.

## Uvod u streaming podataka u realnom vremenu

Streaming podataka u realnom vremenu je tehnološki pristup koji omogućava kontinuirani prenos, obradu i analizu podataka dok se generišu, dozvoljavajući sistemima da odmah reaguju na nove informacije. Za razliku od tradicionalne batch obrade koja radi sa statičkim skupovima podataka, streaming obrađuje podatke u pokretu, pružajući uvide i akcije sa minimalnim kašnjenjem.

### Osnovni koncepti streaminga podataka u realnom vremenu:

- **Kontinuirani tok podataka**: Podaci se obrađuju kao neprekidni, beskonačni niz događaja ili zapisa.
- **Obrada sa niskom latencijom**: Sistemi su dizajnirani da minimizuju vreme između generisanja i obrade podataka.
- **Skalabilnost**: Streaming arhitekture moraju da podnesu varijabilne količine i brzine podataka.
- **Otpornost na greške**: Sistemi treba da budu otporni na kvarove kako bi obezbedili neprekidan tok podataka.
- **Obrada sa stanjem**: Održavanje konteksta između događaja je ključno za smisleno analiziranje.

### Model Context Protocol i streaming u realnom vremenu

Model Context Protocol (MCP) rešava nekoliko ključnih izazova u okruženjima za streaming u realnom vremenu:

1. **Kontekstualna kontinuitet**: MCP standardizuje način na koji se kontekst održava kroz distribuirane streaming komponente, osiguravajući da AI modeli i čvorovi za obradu imaju pristup relevantnom istorijskom i okruženjskom kontekstu.

2. **Efikasno upravljanje stanjem**: Pružajući strukturirane mehanizme za prenos konteksta, MCP smanjuje opterećenje upravljanja stanjem u streaming cevovodima.

3. **Interoperabilnost**: MCP stvara zajednički jezik za deljenje konteksta između različitih streaming tehnologija i AI modela, omogućavajući fleksibilnije i proširive arhitekture.

4. **Streaming-optimizovani kontekst**: Implementacije MCP-a mogu da prioritetizuju koje su elemente konteksta najvažnije za donošenje odluka u realnom vremenu, optimizujući performanse i tačnost.

5. **Adaptivna obrada**: Uz adekvatno upravljanje kontekstom preko MCP-a, streaming sistemi mogu dinamički prilagođavati obradu na osnovu promenljivih uslova i obrazaca u podacima.

U savremenim aplikacijama, od IoT senzorskih mreža do platformi za finansijsko trgovanje, integracija MCP-a sa streaming tehnologijama omogućava inteligentniju, kontekstualno svesnu obradu koja može adekvatno reagovati na složene, promenljive situacije u realnom vremenu.

## Ciljevi učenja

Na kraju ove lekcije, bićete u stanju da:

- Razumete osnove streaminga podataka u realnom vremenu i njegove izazove
- Objasnite kako Model Context Protocol (MCP) poboljšava streaming podataka u realnom vremenu
- Implementirate streaming rešenja zasnovana na MCP koristeći popularne okvire kao što su Kafka i Pulsar
- Dizajnirate i implementirate otporne i visokoperformantne streaming arhitekture sa MCP-om
- Primijenite MCP koncepte u IoT, finansijskom trgovanju i AI-analitici
- Procijenite nove trendove i buduće inovacije u MCP baziranim streaming tehnologijama

### Definicija i značaj

Streaming podataka u realnom vremenu podrazumeva kontinuiranu generaciju, obradu i isporuku podataka sa minimalnim kašnjenjem. Za razliku od batch obrade, gde se podaci prikupljaju i obrađuju u grupama, streaming podaci se obrađuju postepeno kako stižu, omogućavajući trenutne uvide i akcije.

Ključne karakteristike streaminga podataka u realnom vremenu uključuju:

- **Niska latencija**: Obrada i analiza podataka u milisekundama do sekundi
- **Kontinuirani tok**: Neprekidni tokovi podataka iz različitih izvora
- **Neposredna obrada**: Analiza podataka čim stignu, umesto u serijama
- **Arhitektura vođena događajima**: Reagovanje na događaje čim se dogode

### Izazovi u tradicionalnom streamingu podataka

Tradicionalni pristupi streamingu podataka imaju nekoliko ograničenja:

1. **Gubitak konteksta**: Teškoće u održavanju konteksta kroz distribuirane sisteme
2. **Problemi sa skalabilnošću**: Izazovi u skaliranju za rukovanje velikim i brzim količinama podataka
3. **Složenost integracije**: Problemi sa interoperabilnošću između različitih sistema
4. **Upravljanje latencijom**: Balansiranje između protoka i vremena obrade
5. **Konzistentnost podataka**: Obezbeđivanje tačnosti i potpunosti podataka kroz tok

## Razumevanje Model Context Protocol-a (MCP)

### Šta je MCP?

Model Context Protocol (MCP) je standardizovani komunikacioni protokol dizajniran da olakša efikasnu interakciju između AI modela i aplikacija. U kontekstu streaminga podataka u realnom vremenu, MCP pruža okvir za:

- Očuvanje konteksta kroz ceo cevovod podataka
- Standardizaciju formata razmene podataka
- Optimizaciju prenosa velikih skupova podataka
- Poboljšanje komunikacije model-model i model-aplikacija

### Osnovne komponente i arhitektura

MCP arhitektura za streaming u realnom vremenu sastoji se od nekoliko ključnih komponenti:

1. **Context Handlers**: Upravljaju i održavaju kontekstualne informacije kroz streaming cevovod
2. **Stream Processors**: Procesiraju dolazne tokove podataka koristeći tehnike svesne konteksta
3. **Protocol Adapters**: Pretvaraju između različitih streaming protokola uz očuvanje konteksta
4. **Context Store**: Efikasno čuva i vraća kontekstualne informacije
5. **Streaming Connectors**: Povezuju se sa različitim streaming platformama (Kafka, Pulsar, Kinesis itd.)

```mermaid
graph TD
    subgraph "Data Sources"
        IoT[IoT Devices]
        APIs[APIs]
        DB[Databases]
        Apps[Applications]
    end

    subgraph "MCP Streaming Layer"
        SC[Streaming Connectors]
        PA[Protocol Adapters]
        CH[Context Handlers]
        SP[Stream Processors]
        CS[Context Store]
    end

    subgraph "Processing & Analytics"
        RT[Real-time Analytics]
        ML[ML Models]
        CEP[Complex Event Processing]
        Viz[Visualization]
    end

    subgraph "Applications & Services"
        DA[Decision Automation]
        Alerts[Alerting Systems]
        DL[Data Lake/Warehouse]
        API[API Services]
    end

    IoT -->|Data| SC
    APIs -->|Data| SC
    DB -->|Changes| SC
    Apps -->|Events| SC
    
    SC -->|Raw Streams| PA
    PA -->|Normalized Streams| CH
    CH <-->|Context Operations| CS
    CH -->|Context-Enriched Data| SP
    SP -->|Processed Streams| RT
    SP -->|Features| ML
    SP -->|Events| CEP
    
    RT -->|Insights| Viz
    ML -->|Predictions| DA
    CEP -->|Complex Events| Alerts
    Viz -->|Dashboards| Users((Users))
    
    RT -.->|Historical Data| DL
    ML -.->|Model Results| DL
    CEP -.->|Event Logs| DL
    
    DA -->|Actions| API
    Alerts -->|Notifications| API
    DL <-->|Data Access| API
    
    classDef sources fill:#f9f,stroke:#333,stroke-width:2px
    classDef mcp fill:#bbf,stroke:#333,stroke-width:2px
    classDef processing fill:#bfb,stroke:#333,stroke-width:2px
    classDef apps fill:#fbb,stroke:#333,stroke-width:2px
    
    class IoT,APIs,DB,Apps sources
    class SC,PA,CH,SP,CS mcp
    class RT,ML,CEP,Viz processing
    class DA,Alerts,DL,API apps
```

### Kako MCP poboljšava obradu podataka u realnom vremenu

MCP rešava tradicionalne izazove streaminga kroz:

- **Kontekstualni integritet**: Održavanje veza između podataka kroz ceo cevovod
- **Optimizovani prenos**: Smanjenje redundantnosti u razmeni podataka kroz inteligentno upravljanje kontekstom
- **Standardizovani interfejsi**: Pružanje konzistentnih API-ja za streaming komponente
- **Smanjena latencija**: Minimiziranje troškova obrade kroz efikasno rukovanje kontekstom
- **Povećana skalabilnost**: Podrška horizontalnom skaliranju uz očuvanje konteksta

## Integracija i implementacija

Sistemi za streaming podataka u realnom vremenu zahtevaju pažljiv arhitektonski dizajn i implementaciju kako bi održali performanse i kontekstualni integritet. Model Context Protocol nudi standardizovan pristup integraciji AI modela i streaming tehnologija, omogućavajući sofisticiranije, kontekstualno svesne cevovode za obradu.

### Pregled integracije MCP-a u streaming arhitekture

Implementacija MCP-a u okruženjima za streaming u realnom vremenu uključuje nekoliko ključnih aspekata:

1. **Serijalizacija i prenos konteksta**: MCP pruža efikasne mehanizme za kodiranje kontekstualnih informacija unutar streaming paketa podataka, osiguravajući da su ključni kontekstualni podaci prisutni tokom celog procesa. To uključuje standardizovane formate serijalizacije optimizovane za streaming prenos.

2. **Obrada tokova sa stanjem**: MCP omogućava inteligentniju obradu sa stanjem održavanjem konzistentne reprezentacije konteksta kroz čvorove za obradu. Ovo je posebno korisno u distribuiranim streaming arhitekturama gde je upravljanje stanjem tradicionalno izazov.

3. **Vreme događaja naspram vremena obrade**: Implementacije MCP-a u streaming sistemima moraju da adresiraju uobičajeni izazov razlikovanja kada su se događaji desili i kada su obrađeni. Protokol može uključiti vremenski kontekst koji čuva semantiku vremena događaja.

4. **Upravljanje povratnim pritiskom (backpressure)**: Standardizacijom rukovanja kontekstom, MCP pomaže u upravljanju povratnim pritiskom u streaming sistemima, omogućavajući komponentama da komuniciraju svoje kapacitete obrade i prilagođavaju tok podataka.

5. **Prozori i agregacija konteksta**: MCP omogućava složenije operacije prozora pružajući strukturirane reprezentacije vremenskog i relacijskog konteksta, što omogućava smislenije agregacije kroz tokove događaja.

6. **Obrada tačno jednom (exactly-once)**: U streaming sistemima koji zahtevaju tačno jednom semantiku, MCP može uključiti metapodatke obrade koji pomažu u praćenju i verifikaciji statusa obrade kroz distribuirane komponente.

Implementacija MCP-a preko različitih streaming tehnologija kreira jedinstven pristup upravljanju kontekstom, smanjujući potrebu za prilagođenim integracionim kodom dok istovremeno poboljšava sposobnost sistema da održi smisleni kontekst tokom protoka podataka.

### MCP u različitim framework-ovima za streaming podataka

Ovi primeri prate aktuelnu MCP specifikaciju koja se bazira na JSON-RPC protokolu sa različitim mehanizmima transporta. Kod pokazuje kako možete implementirati prilagođene transportere koji integrišu streaming platforme kao što su Kafka i Pulsar, uz punu kompatibilnost sa MCP protokolom.

Primeri su dizajnirani da pokažu kako se streaming platforme mogu integrisati sa MCP-om kako bi obezbedili obradu podataka u realnom vremenu uz očuvanje kontekstualne svesti koja je centralna za MCP. Ovaj pristup osigurava da kod primeri tačno odražavaju trenutno stanje MCP specifikacije na jun 2025.

MCP se može integrisati sa popularnim streaming framework-ovima, uključujući:

#### Integracija sa Apache Kafka

```python
import asyncio
import json
from typing import Dict, Any, Optional
from confluent_kafka import Consumer, Producer, KafkaError
from mcp.client import Client, ClientCapabilities
from mcp.core.message import JsonRpcMessage
from mcp.core.transports import Transport

# Custom transport class to bridge MCP with Kafka
class KafkaMCPTransport(Transport):
    def __init__(self, bootstrap_servers: str, input_topic: str, output_topic: str):
        self.bootstrap_servers = bootstrap_servers
        self.input_topic = input_topic
        self.output_topic = output_topic
        self.producer = Producer({'bootstrap.servers': bootstrap_servers})
        self.consumer = Consumer({
            'bootstrap.servers': bootstrap_servers,
            'group.id': 'mcp-client-group',
            'auto.offset.reset': 'earliest'
        })
        self.message_queue = asyncio.Queue()
        self.running = False
        self.consumer_task = None
        
    async def connect(self):
        """Connect to Kafka and start consuming messages"""
        self.consumer.subscribe([self.input_topic])
        self.running = True
        self.consumer_task = asyncio.create_task(self._consume_messages())
        return self
        
    async def _consume_messages(self):
        """Background task to consume messages from Kafka and queue them for processing"""
        while self.running:
            try:
                msg = self.consumer.poll(1.0)
                if msg is None:
                    await asyncio.sleep(0.1)
                    continue
                
                if msg.error():
                    if msg.error().code() == KafkaError._PARTITION_EOF:
                        continue
                    print(f"Consumer error: {msg.error()}")
                    continue
                
                # Parse the message value as JSON-RPC
                try:
                    message_str = msg.value().decode('utf-8')
                    message_data = json.loads(message_str)
                    mcp_message = JsonRpcMessage.from_dict(message_data)
                    await self.message_queue.put(mcp_message)
                except Exception as e:
                    print(f"Error parsing message: {e}")
            except Exception as e:
                print(f"Error in consumer loop: {e}")
                await asyncio.sleep(1)
    
    async def read(self) -> Optional[JsonRpcMessage]:
        """Read the next message from the queue"""
        try:
            message = await self.message_queue.get()
            return message
        except Exception as e:
            print(f"Error reading message: {e}")
            return None
    
    async def write(self, message: JsonRpcMessage) -> None:
        """Write a message to the Kafka output topic"""
        try:
            message_json = json.dumps(message.to_dict())
            self.producer.produce(
                self.output_topic,
                message_json.encode('utf-8'),
                callback=self._delivery_report
            )
            self.producer.poll(0)  # Trigger callbacks
        except Exception as e:
            print(f"Error writing message: {e}")
    
    def _delivery_report(self, err, msg):
        """Kafka producer delivery callback"""
        if err is not None:
            print(f'Message delivery failed: {err}')
        else:
            print(f'Message delivered to {msg.topic()} [{msg.partition()}]')
    
    async def close(self) -> None:
        """Close the transport"""
        self.running = False
        if self.consumer_task:
            self.consumer_task.cancel()
            try:
                await self.consumer_task
            except asyncio.CancelledError:
                pass
        self.consumer.close()
        self.producer.flush()

# Example usage of the Kafka MCP transport
async def kafka_mcp_example():
    # Create MCP client with Kafka transport
    client = Client(
        {"name": "kafka-mcp-client", "version": "1.0.0"},
        ClientCapabilities({})
    )
    
    # Create and connect the Kafka transport
    transport = KafkaMCPTransport(
        bootstrap_servers="localhost:9092",
        input_topic="mcp-responses",
        output_topic="mcp-requests"
    )
    
    await client.connect(transport)
    
    try:
        # Initialize the MCP session
        await client.initialize()
        
        # Example of executing a tool via MCP
        response = await client.execute_tool(
            "process_data",
            {
                "data": "sample data",
                "metadata": {
                    "source": "sensor-1",
                    "timestamp": "2025-06-12T10:30:00Z"
                }
            }
        )
        
        print(f"Tool execution response: {response}")
        
        # Clean shutdown
        await client.shutdown()
    finally:
        await transport.close()

# Run the example
if __name__ == "__main__":
    asyncio.run(kafka_mcp_example())
```

#### Implementacija sa Apache Pulsar

```python
import asyncio
import json
import pulsar
from typing import Dict, Any, Optional
from mcp.core.message import JsonRpcMessage
from mcp.core.transports import Transport
from mcp.server import Server, ServerOptions
from mcp.server.tools import Tool, ToolExecutionContext, ToolMetadata

# Create a custom MCP transport that uses Pulsar
class PulsarMCPTransport(Transport):
    def __init__(self, service_url: str, request_topic: str, response_topic: str):
        self.service_url = service_url
        self.request_topic = request_topic
        self.response_topic = response_topic
        self.client = pulsar.Client(service_url)
        self.producer = self.client.create_producer(response_topic)
        self.consumer = self.client.subscribe(
            request_topic,
            "mcp-server-subscription",
            consumer_type=pulsar.ConsumerType.Shared
        )
        self.message_queue = asyncio.Queue()
        self.running = False
        self.consumer_task = None
    
    async def connect(self):
        """Connect to Pulsar and start consuming messages"""
        self.running = True
        self.consumer_task = asyncio.create_task(self._consume_messages())
        return self
    
    async def _consume_messages(self):
        """Background task to consume messages from Pulsar and queue them for processing"""
        while self.running:
            try:
                # Non-blocking receive with timeout
                msg = self.consumer.receive(timeout_millis=500)
                
                # Process the message
                try:
                    message_str = msg.data().decode('utf-8')
                    message_data = json.loads(message_str)
                    mcp_message = JsonRpcMessage.from_dict(message_data)
                    await self.message_queue.put(mcp_message)
                    
                    # Acknowledge the message
                    self.consumer.acknowledge(msg)
                except Exception as e:
                    print(f"Error processing message: {e}")
                    # Negative acknowledge if there was an error
                    self.consumer.negative_acknowledge(msg)
            except Exception as e:
                # Handle timeout or other exceptions
                await asyncio.sleep(0.1)
    
    async def read(self) -> Optional[JsonRpcMessage]:
        """Read the next message from the queue"""
        try:
            message = await self.message_queue.get()
            return message
        except Exception as e:
            print(f"Error reading message: {e}")
            return None
    
    async def write(self, message: JsonRpcMessage) -> None:
        """Write a message to the Pulsar output topic"""
        try:
            message_json = json.dumps(message.to_dict())
            self.producer.send(message_json.encode('utf-8'))
        except Exception as e:
            print(f"Error writing message: {e}")
    
    async def close(self) -> None:
        """Close the transport"""
        self.running = False
        if self.consumer_task:
            self.consumer_task.cancel()
            try:
                await self.consumer_task
            except asyncio.CancelledError:
                pass
        self.consumer.close()
        self.producer.close()
        self.client.close()

# Define a sample MCP tool that processes streaming data
@Tool(
    name="process_streaming_data",
    description="Process streaming data with context preservation",
    metadata=ToolMetadata(
        required_capabilities=["streaming"]
    )
)
async def process_streaming_data(
    ctx: ToolExecutionContext,
    data: str,
    source: str,
    priority: str = "medium"
) -> Dict[str, Any]:
    """
    Process streaming data while preserving context
    
    Args:
        ctx: Tool execution context
        data: The data to process
        source: The source of the data
        priority: Priority level (low, medium, high)
        
    Returns:
        Dict containing processed results and context information
    """
    # Example processing that leverages MCP context
    print(f"Processing data from {source} with priority {priority}")
    
    # Access conversation context from MCP
    conversation_id = ctx.conversation_id if hasattr(ctx, 'conversation_id') else "unknown"
    
    # Return results with enhanced context
    return {
        "processed_data": f"Processed: {data}",
        "context": {
            "conversation_id": conversation_id,
            "source": source,
            "priority": priority,
            "processing_timestamp": ctx.get_current_time_iso()
        }
    }

# Example MCP server implementation using Pulsar transport
async def run_mcp_server_with_pulsar():
    # Create MCP server
    server = Server(
        {"name": "pulsar-mcp-server", "version": "1.0.0"},
        ServerOptions(
            capabilities={"streaming": True}
        )
    )
    
    # Register our tool
    server.register_tool(process_streaming_data)
    
    # Create and connect Pulsar transport
    transport = PulsarMCPTransport(
        service_url="pulsar://localhost:6650",
        request_topic="mcp-requests",
        response_topic="mcp-responses"
    )
    
    try:
        # Start the server with the Pulsar transport
        await server.run(transport)
    finally:
        await transport.close()

# Run the server
if __name__ == "__main__":
    asyncio.run(run_mcp_server_with_pulsar())
```

### Najbolje prakse za implementaciju

Prilikom implementacije MCP-a za streaming u realnom vremenu:

1. **Dizajnirajte za otpornost na greške**:
   - Implementirajte adekvatno rukovanje greškama
   - Koristite dead-letter queue za neuspele poruke
   - Dizajnirajte idempotentne procesore

2. **Optimizujte performanse**:
   - Konfigurišite odgovarajuće veličine bafera
   - Koristite grupisanje poruka gde je prikladno
   - Implementirajte mehanizme za povratni pritisak

3. **Pratite i posmatrajte**:
   - Pratite metrike obrade toka
   - Nadgledajte propagaciju konteksta
   - Postavite alarme za anomalije

4. **Osigurajte tokove**:
   - Implementirajte enkripciju za osetljive podatke
   - Koristite autentifikaciju i autorizaciju
   - Primijenite odgovarajuće kontrole pristupa

### MCP u IoT i Edge računarstvu

MCP poboljšava IoT streaming tako što:

- Očuva kontekst uređaja kroz cevovod obrade
- Omogućava efikasan streaming podataka sa edge uređaja do oblaka
- Podržava analitiku u realnom vremenu na IoT tokovima podataka
- Omogućava komunikaciju uređaj-uređaj sa kontekstom

Primer: Mreže senzora u pametnim gradovima  
```
Sensors → Edge Gateways → MCP Stream Processors → Real-time Analytics → Automated Responses
```

### Uloga u finansijskim transakcijama i trgovanju visokih frekvencija

MCP donosi značajne prednosti za finansijski streaming podataka:

- Ultra-niska latencija obrade za trgovačke odluke
- Održavanje konteksta transakcija tokom obrade
- Podrška složenoj obradi događaja sa kontekstualnom svesnošću
- Obezbeđivanje konzistentnosti podataka u distribuiranim trgovačkim sistemima

### Unapređenje AI-vođene analitike podataka

MCP otvara nove mogućnosti za streaming analitiku:

- Trening i inferencija modela u realnom vremenu
- Kontinuirano učenje iz streaming podataka
- Ekstrakcija karakteristika sa svesti o kontekstu
- Višemodelski inferencijski cevovodi sa očuvanim kontekstom

## Budući trendovi i inovacije

### Evolucija MCP-a u realnim vremenskim okruženjima

Gledajući unapred, očekujemo da će MCP evoluirati kako bi adresirao:

- **Integraciju kvantnog računarstva**: Priprema za kvantne streaming sisteme
- **Edge-native obradu**: Premještanje više kontekstualno svesne obrade na edge uređaje
- **Autonomno upravljanje streamingom**: Samooptimizujući streaming cevovodi
- **Federisani streaming**: Distribuirana obrada uz očuvanje privatnosti

### Potencijalni tehnološki napreci

Nove tehnologije koje će oblikovati budućnost MCP streaminga:

1. **AI-optimizovani streaming protokoli**: Prilagođeni protokoli posebno dizajnirani za AI zadatke
2. **Integracija neuromorfičkog računarstva**: Računarstvo inspirisano mozgom za obradu tokova
3. **Serverless streaming**: Event-driven, skalabilan streaming bez upravljanja infrastrukturom
4. **Distribuirane baze konteksta**: Globalno distribuirano, ali visoko konzistentno upravljanje kontekstom

## Praktične vežbe

### Vežba 1: Postavljanje osnovnog MCP streaming cevovoda

U ovoj vežbi ćete naučiti kako da:
- Konfigurišete osnovno MCP streaming okruženje
- Implementirate context handlere za obradu tokova
- Testirate i potvrdite očuvanje konteksta

### Vežba 2: Izrada dashboarda za analitiku u realnom vremenu

Kreirajte kompletnu aplikaciju koja:
- Prima streaming podatke koristeći MCP
- Procesira tok uz održavanje konteksta
- Vizualizuje rezultate u realnom vremenu

### Vežba 3: Implementacija složene obrade događaja sa MCP-om

Napredna vežba koja pokriva:
- Detekciju obrazaca u tokovima
- Kontekstualnu korelaciju između više tokova
- Generisanje složenih događaja sa očuvanim kontekstom

## Dodatni resursi

- [Model Context Protocol Specification](https://github.com/modelcontextprotocol) - Zvanična MCP specifikacija i dokumentacija  
- [Apache Kafka Documentation](https://kafka.apache.org/documentation/) - Naučite o Kafki za obradu tokova  
- [Apache Pulsar](https://pulsar.apache.org/) - Jedinstvena platforma za poruke i streaming  
- [Streaming Systems: The What, Where, When, and How of Large-Scale Data Processing](https://www.oreilly.com/library/view/streaming-systems/9781491983867/) - Sveobuhvatna knjiga o streaming arhitekturama  
- [Microsoft Azure Event Hubs](https://learn.microsoft.com/azure/event-hubs/event-hubs-about) - Upravljačka usluga za streaming događaja  
- [MLflow Documentation](https://mlflow.org/docs/latest/index.html) - Za praćenje i implementaciju ML modela  
- [Real-Time Analytics with Apache Storm](https://storm.apache.org/releases/current/index.html) - Framework za obradu u realnom vremenu  
- [Flink ML](https://nightlies.apache.org/flink/flink-ml-docs-master/) - Biblioteka za mašinsko učenje za Apache Flink  
- [LangChain Documentation](https://python.langchain.com/docs/get_started/introduction) - Izrada aplikacija sa LLM-ovima

## Ishodi učenja

Nakon završetka ovog modula, bićete u stanju da:

- Razumete osnove streaminga podataka u realnom vremenu i njegove izazove  
- Objasnite kako Model Context Protocol (MCP) poboljšava streaming podataka u realnom vremenu  
- Implementirate MCP bazirana streaming rešenja koristeći popularne okvire kao što su Kafka i Pulsar  
- Dizajnirate i implementirate ot

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем AI преводилачке услуге [Co-op Translator](https://github.com/Azure/co-op-translator). Иако тежимо прецизности, имајте у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешна тумачења која произилазе из коришћења овог превода.