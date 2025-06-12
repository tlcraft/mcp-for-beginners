<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b41174ac781ebf228b2043cbdfc09105",
  "translation_date": "2025-06-12T00:51:08+00:00",
  "source_file": "05-AdvancedTopics/mcp-realtimestreaming/README.md",
  "language_code": "sl"
}
-->
# Model Context Protocol za Real-Time Data Streaming

## Pregled

Real-time data streaming je postal ključnega pomena v današnjem svetu, ki temelji na podatkih, kjer podjetja in aplikacije potrebujejo takojšen dostop do informacij za pravočasno sprejemanje odločitev. Model Context Protocol (MCP) predstavlja pomemben napredek pri optimizaciji teh real-time streaming procesov, izboljšuje učinkovitost obdelave podatkov, ohranja kontekstualno celovitost in povečuje splošno zmogljivost sistema.

Ta modul raziskuje, kako MCP spreminja real-time data streaming z zagotavljanjem standardiziranega pristopa k upravljanju konteksta med AI modeli, streaming platformami in aplikacijami.

## Uvod v Real-Time Data Streaming

Real-time data streaming je tehnološki koncept, ki omogoča neprekinjeno prenašanje, obdelavo in analizo podatkov takoj, ko nastanejo, kar sistemom omogoča takojšen odziv na nove informacije. V nasprotju s tradicionalno obdelavo v serijah, ki deluje na statičnih podatkih, streaming obdeluje podatke v gibanju in zagotavlja vpoglede ter ukrepe z minimalno zakasnitvijo.

### Osnovni pojmi real-time data streaminga:

- **Neprekinjen pretok podatkov**: Podatki se obdelujejo kot neprekinjen, neskončen tok dogodkov ali zapisov.
- **Obdelava z nizko zakasnitvijo**: Sistemi so zasnovani tako, da zmanjšajo čas med generiranjem in obdelavo podatkov.
- **Razširljivost**: Streaming arhitekture morajo obvladovati spremenljive količine in hitrost podatkov.
- **Odpornost na napake**: Sistemi morajo biti odporni na napake, da zagotovijo neprekinjen pretok podatkov.
- **Stanje obdelave**: Ohranjanje konteksta med dogodki je ključno za smiselno analizo.

### Model Context Protocol in Real-Time Streaming

Model Context Protocol (MCP) rešuje več ključnih izzivov v real-time streaming okoljih:

1. **Kontekstualna kontinuiteta**: MCP standardizira način ohranjanja konteksta med distribuiranimi streaming komponentami, kar zagotavlja, da imajo AI modeli in procesni vozli dostop do relevantnega zgodovinskega in okoljskega konteksta.

2. **Učinkovito upravljanje stanja**: Z zagotavljanjem strukturiranih mehanizmov za prenos konteksta MCP zmanjšuje obremenitev upravljanja stanja v streaming cevovodih.

3. **Medsebojna združljivost**: MCP ustvarja skupni jezik za deljenje konteksta med različnimi streaming tehnologijami in AI modeli, kar omogoča bolj prilagodljive in razširljive arhitekture.

4. **Streaming-optimiran kontekst**: Implementacije MCP lahko prioritizirajo, kateri elementi konteksta so najbolj pomembni za real-time odločanje, s čimer optimizirajo tako zmogljivost kot natančnost.

5. **Prilagodljiva obdelava**: Z ustreznim upravljanjem konteksta preko MCP lahko streaming sistemi dinamično prilagajajo obdelavo glede na spreminjajoče se pogoje in vzorce v podatkih.

V sodobnih aplikacijah, od IoT senzornih omrežij do finančnih trgovalnih platform, integracija MCP s streaming tehnologijami omogoča bolj inteligentno, kontekstualno ozaveščeno obdelavo, ki se lahko primerno odziva na kompleksne in spreminjajoče se situacije v realnem času.

## Cilji učenja

Ob koncu te lekcije boste lahko:

- Razumeli osnovne pojme real-time data streaminga in njegove izzive
- Pojasnili, kako Model Context Protocol (MCP) izboljšuje real-time data streaming
- Implementirali streaming rešitve na osnovi MCP z uporabo priljubljenih ogrodij, kot sta Kafka in Pulsar
- Načrtovali in uvedli odpornost proti napakam ter visoko zmogljive streaming arhitekture z MCP
- Uporabili koncepte MCP v primerih uporabe IoT, finančnega trgovanja in analitike, ki jo poganja AI
- Ocenili nove trende in prihodnje inovacije v tehnologijah streamingov na osnovi MCP

### Definicija in pomen

Real-time data streaming vključuje neprekinjeno generiranje, obdelavo in dostavo podatkov z minimalno zakasnitvijo. V nasprotju z obdelavo v serijah, kjer se podatki zbirajo in obdelujejo v skupinah, se streaming podatki obdelujejo postopoma, takoj ko prispejo, kar omogoča takojšnje vpoglede in ukrepe.

Ključne značilnosti real-time data streaminga so:

- **Nizka zakasnitev**: Obdelava in analiza podatkov v milisekundah do sekundah
- **Neprekinjen pretok**: Neprekinjeni tokovi podatkov iz različnih virov
- **Takojšnja obdelava**: Analiza podatkov takoj ob prihodu, ne v serijah
- **Arhitektura, ki temelji na dogodkih**: Odzivanje na dogodke takoj, ko se zgodijo

### Izzivi tradicionalnega data streaminga

Tradicionalni pristopi k data streamingu se soočajo z več omejitvami:

1. **Izguba konteksta**: Težave pri ohranjanju konteksta med distribuiranimi sistemi
2. **Težave z razširljivostjo**: Izzivi pri prilagajanju visokim količinam in hitrosti podatkov
3. **Kompleksnost integracije**: Težave z medsebojno združljivostjo med različnimi sistemi
4. **Upravljanje zakasnitve**: Uravnoteženje prepustnosti in časa obdelave
5. **Konsistentnost podatkov**: Zagotavljanje natančnosti in popolnosti podatkov skozi tok

## Razumevanje Model Context Protocol (MCP)

### Kaj je MCP?

Model Context Protocol (MCP) je standardiziran komunikacijski protokol, zasnovan za učinkovito interakcijo med AI modeli in aplikacijami. V kontekstu real-time data streaminga MCP zagotavlja okvir za:

- Ohranjanje konteksta skozi celoten podatkovni cevovod
- Standardizacijo formatov izmenjave podatkov
- Optimizacijo prenosa velikih podatkovnih nizov
- Izboljšanje komunikacije med modeli in med modeli ter aplikacijami

### Osnovne komponente in arhitektura

Arhitektura MCP za real-time streaming obsega več ključnih komponent:

1. **Context Handlers**: Upravljajo in vzdržujejo kontekstualne informacije skozi streaming cevovod
2. **Stream Processors**: Obdelujejo vhodne podatkovne tokove z uporabo tehnik, ki upoštevajo kontekst
3. **Protocol Adapters**: Pretvarjajo med različnimi streaming protokoli ob ohranjanju konteksta
4. **Context Store**: Učinkovito shranjuje in pridobiva kontekstualne informacije
5. **Streaming Connectors**: Povezujejo se z različnimi streaming platformami (Kafka, Pulsar, Kinesis itd.)

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

### Kako MCP izboljšuje obdelavo real-time podatkov

MCP rešuje tradicionalne izzive streaminga z:

- **Kontekstualno celovitostjo**: Ohranjanjem povezav med podatkovnimi točkami skozi celoten cevovod
- **Optimiziranim prenosom**: Zmanjševanjem podvajanja v izmenjavi podatkov z inteligentnim upravljanjem konteksta
- **Standardiziranimi vmesniki**: Zagotavljanjem doslednih API-jev za streaming komponente
- **Zmanjšano zakasnitvijo**: Minimiziranjem procesnih stroškov z učinkovitim ravnanjem s kontekstom
- **Izboljšano razširljivostjo**: Podpiranjem horizontalne razširitve ob ohranjanju konteksta

## Integracija in implementacija

Sistemi za real-time data streaming zahtevajo skrbno arhitekturno zasnovo in izvedbo, da ohranijo tako zmogljivost kot tudi kontekstualno celovitost. Model Context Protocol ponuja standardiziran pristop k integraciji AI modelov in streaming tehnologij, kar omogoča bolj sofisticirane, kontekstualno ozaveščene obdelovalne cevovode.

### Pregled integracije MCP v streaming arhitekture

Implementacija MCP v real-time streaming okoljih vključuje več ključnih vidikov:

1. **Serilizacija in prenos konteksta**: MCP zagotavlja učinkovite mehanizme za kodiranje kontekstualnih informacij znotraj podatkovnih paketov v streamu, s čimer zagotavlja, da ključni kontekst spremlja podatke skozi celoten cevovod. To vključuje standardizirane formate serializacije, optimizirane za streaming prenos.

2. **Stanje obdelave toka**: MCP omogoča pametnejšo obdelavo z ohranjanjem dosledne predstavitve konteksta med procesnimi vozlišči. To je še posebej pomembno v distribuiranih streaming arhitekturah, kjer je upravljanje stanja običajno zahtevno.

3. **Čas dogodka proti času obdelave**: Implementacije MCP v streaming sistemih morajo nasloviti pogosto težavo razlikovanja med časom, ko se je dogodek zgodil, in časom njegove obdelave. Protokol lahko vključuje časovni kontekst, ki ohranja semantiko časa dogodka.

4. **Upravljanje povratnega pritiska (backpressure)**: Z standardiziranim ravnanjem s kontekstom MCP pomaga upravljati povratni pritisk v streaming sistemih, kar omogoča komponentam, da sporočajo svoje zmogljivosti obdelave in prilagodijo pretok.

5. **Okno in agregacija konteksta**: MCP omogoča bolj sofisticirane operacije z okni s strukturiranimi predstavitvami časovnega in relacijskega konteksta, kar omogoča smiselnejše agregacije prek tokov dogodkov.

6. **Obdelava točno enkrat (exactly-once)**: V streaming sistemih, ki zahtevajo semantiko točno enkrat, lahko MCP vključi metapodatke o obdelavi, ki pomagajo slediti in preverjati status obdelave med distribuiranimi komponentami.

Implementacija MCP v različnih streaming tehnologijah ustvarja enoten pristop k upravljanju konteksta, zmanjšuje potrebo po prilagojenih integracijskih rešitvah in izboljšuje sposobnost sistema, da ohrani smiselni kontekst med pretokom podatkov.

### MCP v različnih okvirjih za data streaming

Ti primeri sledijo trenutni specifikaciji MCP, ki temelji na JSON-RPC protokolu z različnimi transportnimi mehanizmi. Koda prikazuje, kako lahko implementirate prilagojene transporte, ki integrirajo streaming platforme, kot sta Kafka in Pulsar, ob ohranjanju popolne združljivosti s protokolom MCP.

Primeri so zasnovani tako, da pokažejo, kako je mogoče streaming platforme povezati z MCP za zagotavljanje real-time obdelave podatkov ob ohranjanju kontekstualne ozaveščenosti, ki je osrednjega pomena za MCP. Ta pristop zagotavlja, da vzorci kode natančno odražajo trenutno stanje specifikacije MCP do junija 2025.

MCP je mogoče integrirati s priljubljenimi streaming ogrodji, med drugim:

#### Integracija Apache Kafka

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

#### Implementacija Apache Pulsar

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

### Najboljše prakse za uvedbo

Pri implementaciji MCP za real-time streaming:

1. **Zasnova za odpornost proti napakam**:
   - Uvedite ustrezno ravnanje z napakami
   - Uporabite dead-letter queue za neuspešna sporočila
   - Oblikujte idempotentne procesorje

2. **Optimizacija za zmogljivost**:
   - Nastavite primerne velikosti predpomnilnikov
   - Uporabite združevanje (batching), kjer je primerno
   - Uvedite mehanizme za upravljanje povratnega pritiska

3. **Nadzor in opazovanje**:
   - Spremljajte metrike obdelave toka
   - Nadzorujte propagacijo konteksta
   - Nastavite opozorila za anomalije

4. **Zavarujte svoje tokove**:
   - Uvedite šifriranje za občutljive podatke
   - Uporabite avtentikacijo in avtorizacijo
   - Uporabite ustrezne kontrole dostopa

### MCP v IoT in edge računalništvu

MCP izboljšuje IoT streaming z:

- Ohranjanjem konteksta naprav skozi cevovod obdelave
- Omogočanjem učinkovitega prenosa podatkov od edge do oblaka
- Podporo real-time analitiki IoT podatkovnih tokov
- Olajšanjem komunikacije med napravami z ohranjenim kontekstom

Primer: Senzorska omrežja pametnih mest  
```
Sensors → Edge Gateways → MCP Stream Processors → Real-time Analytics → Automated Responses
```

### Vloga v finančnih transakcijah in visokofrekvenčnem trgovanju

MCP prinaša pomembne prednosti za finančni data streaming:

- Izjemno nizka zakasnitev pri trgovalnih odločitvah
- Ohranjanje transakcijskega konteksta skozi obdelavo
- Podpora kompleksni obdelavi dogodkov s kontekstualno ozaveščenostjo
- Zagotavljanje konsistentnosti podatkov v distribuiranih trgovalnih sistemih

### Izboljšanje analitike, ki jo poganja AI

MCP odpira nove možnosti za streaming analitiko:

- Real-time usposabljanje modelov in sklepanje
- Neprekinjeno učenje iz streaming podatkov
- Ekstrakcija značilnosti z ozaveščenostjo o kontekstu
- Večmodelni sklepalni cevovodi z ohranjenim kontekstom

## Prihodnji trendi in inovacije

### Evolucija MCP v real-time okoljih

V prihodnosti pričakujemo, da se bo MCP razvijal za reševanje:

- **Integracije kvantnega računalništva**: Priprava na streaming sisteme, ki temeljijo na kvantnem računalništvu
- **Edge-nativna obdelava**: Premik več kontekstualno ozaveščene obdelave na edge naprave
- **Avtonomno upravljanje tokov**: Samooptimizirajoči streaming cevovodi
- **Federirani streaming**: Distribuirana obdelava ob ohranjanju zasebnosti

### Potencialni tehnološki napredki

Nove tehnologije, ki bodo oblikovale prihodnost MCP streaminga:

1. **AI-optimizirani streaming protokoli**: Prilagojeni protokoli, zasnovani posebej za AI delovne obremenitve
2. **Integracija neuromorfnega računalništva**: Računalništvo, navdihnjeno z delovanjem možganov, za obdelavo tokov
3. **Serverless streaming**: Dogodkovno vodeno, razširljivo streamanje brez upravljanja infrastrukture
4. **Distribuirani shranjevalniki konteksta**: Globalno distribuirano, a visoko konsistentno upravljanje konteksta

## Praktične vaje

### Vaja 1: Nastavitev osnovnega MCP streaming cevovoda

V tej vaji se boste naučili:

- Konfigurirati osnovno MCP streaming okolje
- Implementirati context handlerje za obdelavo toka
- Testirati in preveriti ohranjanje konteksta

### Vaja 2: Izgradnja nadzorne plošče za real-time analitiko

Ustvarite celovito aplikacijo, ki:

- Sprejema streaming podatke preko MCP
- Obdeluje tok ob ohranjanju konteksta
- Vizualizira rezultate v realnem času

### Vaja 3: Implementacija kompleksne obdelave dogodkov z MCP

Napredna vaja, ki zajema:

- Odkrivanje vzorcev v tokovih
- Kontekstualno korelacijo med več tokovi
- Generiranje kompleksnih dogodkov z ohranjenim kontekstom

## Dodatni viri

- [Model Context Protocol Specification](https://github.com/modelcontextprotocol) - Uradna MCP specifikacija in dokumentacija
- [Apache Kafka Documentation](https://kafka.apache.org/documentation/) - Spoznajte Kafka za obdelavo tokov
- [Apache Pulsar](https://pulsar.apache.org/) - Združena platforma za sporočanje in streaming
- [Streaming Systems: The What, Where, When, and How of Large-Scale Data Processing](https://www.oreilly.com/library/view/streaming-systems/9781491983867/) - Celovita knjiga o streaming arhitekturah
- [Microsoft Azure Event Hubs](https://learn.microsoft.com/azure/event-hubs/event-hubs-about) - Upravljana storitev za event streaming
- [MLflow Documentation](https://mlflow.org/docs/latest/index.html) - Za sledenje in uvajanje ML modelov
- [Real-Time Analytics with Apache Storm](https://storm.apache.org/releases/current/index.html) - Okvir za obdelavo v realnem času
- [Flink ML](https://nightlies.apache.org/flink/flink-ml-docs-master/) - Knjižnica za strojno učenje za Apache Flink
- [LangChain Documentation](https://python.langchain.com/docs/get_started/introduction) - Gradnja aplikacij z LLM-ji

## Rezultati učenja

Z dokončanjem tega modula boste lahko:

- Razumeli osnovne poj

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v izvirnem jeziku velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Nismo odgovorni za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.