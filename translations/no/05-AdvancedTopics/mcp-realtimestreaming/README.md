<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b41174ac781ebf228b2043cbdfc09105",
  "translation_date": "2025-06-12T00:36:58+00:00",
  "source_file": "05-AdvancedTopics/mcp-realtimestreaming/README.md",
  "language_code": "no"
}
-->
# Modellkontekstprotokoll for sanntids datastrømming

## Oversikt

Sanntids datastrømming har blitt avgjørende i dagens datadrevne verden, hvor bedrifter og applikasjoner trenger umiddelbar tilgang til informasjon for å ta raske beslutninger. Modellkontekstprotokollen (MCP) representerer et betydelig fremskritt i optimaliseringen av disse sanntidsstrømmene, ved å forbedre databehandlings-effektiviteten, opprettholde kontekstuell integritet og øke den totale systemytelsen.

Denne modulen utforsker hvordan MCP forvandler sanntids datastrømming ved å tilby en standardisert tilnærming til kontekststyring på tvers av AI-modeller, strømmeplattformer og applikasjoner.

## Innføring i sanntids datastrømming

Sanntids datastrømming er et teknologisk paradigme som muliggjør kontinuerlig overføring, behandling og analyse av data mens de genereres, slik at systemer kan reagere umiddelbart på ny informasjon. I motsetning til tradisjonell batch-behandling som opererer på statiske datasett, behandler streaming data i bevegelse, og leverer innsikt og handlinger med minimal forsinkelse.

### Kjernebegreper for sanntids datastrømming:

- **Kontinuerlig dataflyt**: Data behandles som en kontinuerlig, uavbrutt strøm av hendelser eller poster.
- **Lav latensbehandling**: Systemer er designet for å minimere tiden mellom datagenerering og behandling.
- **Skalerbarhet**: Streamingarkitekturer må håndtere varierende datavolumer og hastigheter.
- **Feiltoleranse**: Systemer må være robuste mot feil for å sikre uavbrutt dataflyt.
- **Stateful behandling**: Å opprettholde kontekst på tvers av hendelser er avgjørende for meningsfull analyse.

### Modellkontekstprotokollen og sanntids streaming

Modellkontekstprotokollen (MCP) løser flere kritiske utfordringer i sanntids streamingmiljøer:

1. **Kontekstuell kontinuitet**: MCP standardiserer hvordan kontekst opprettholdes på tvers av distribuerte strømme-komponenter, slik at AI-modeller og behandlingsnoder har tilgang til relevant historisk og miljømessig kontekst.

2. **Effektiv tilstandshåndtering**: Ved å tilby strukturerte mekanismer for kontekstoverføring, reduserer MCP overhead knyttet til tilstandshåndtering i streaming-pipelines.

3. **Interoperabilitet**: MCP skaper et felles språk for kontekstdeling mellom ulike streamingteknologier og AI-modeller, noe som muliggjør mer fleksible og utvidbare arkitekturer.

4. **Streaming-optimalisert kontekst**: MCP-implementasjoner kan prioritere hvilke kontekstelementer som er mest relevante for sanntids beslutningstaking, og optimalisere både ytelse og nøyaktighet.

5. **Adaptiv behandling**: Med riktig kontekststyring gjennom MCP kan streamingsystemer dynamisk justere behandlingen basert på endrende forhold og mønstre i dataene.

I moderne applikasjoner, fra IoT-sensornettverk til finansielle handelsplattformer, muliggjør integrasjonen av MCP med streamingteknologier mer intelligent, kontekstbevisst behandling som kan reagere hensiktsmessig på komplekse og dynamiske situasjoner i sanntid.

## Læringsmål

Etter denne leksjonen skal du kunne:

- Forstå grunnleggende prinsipper for sanntids datastrømming og utfordringene knyttet til det
- Forklare hvordan Modellkontekstprotokollen (MCP) forbedrer sanntids datastrømming
- Implementere MCP-baserte streamingløsninger ved hjelp av populære rammeverk som Kafka og Pulsar
- Designe og distribuere feiltolerante, høyytelses streamingarkitekturer med MCP
- Anvende MCP-konsepter på IoT, finanshandel og AI-drevne analysebrukstilfeller
- Vurdere nye trender og fremtidige innovasjoner innen MCP-baserte streamingteknologier

### Definisjon og betydning

Sanntids datastrømming innebærer kontinuerlig generering, behandling og levering av data med minimal forsinkelse. I motsetning til batch-behandling, hvor data samles og behandles i grupper, behandles streamingdata inkrementelt etter hvert som de kommer inn, noe som muliggjør umiddelbar innsikt og handling.

Viktige kjennetegn ved sanntids datastrømming inkluderer:

- **Lav latens**: Behandling og analyse av data innen millisekunder til sekunder
- **Kontinuerlig flyt**: Uavbrutte datastrømmer fra ulike kilder
- **Umiddelbar behandling**: Analyse av data ved ankomst i stedet for i batch
- **Hendelsesdrevet arkitektur**: Respons på hendelser i det de skjer

### Utfordringer i tradisjonell datastrømming

Tradisjonelle tilnærminger til datastrømming møter flere begrensninger:

1. **Kontekstkaps**: Vanskeligheter med å opprettholde kontekst på tvers av distribuerte systemer
2. **Skalerbarhetsproblemer**: Utfordringer med å håndtere høyt volum og høy hastighet på data
3. **Integrasjonskompleksitet**: Problemer med interoperabilitet mellom ulike systemer
4. **Latensstyring**: Balansering mellom gjennomstrømning og behandlingstid
5. **Datakonsistens**: Sikre nøyaktighet og fullstendighet i data gjennom hele strømmen

## Forståelse av Modellkontekstprotokollen (MCP)

### Hva er MCP?

Modellkontekstprotokollen (MCP) er en standardisert kommunikasjonsprotokoll designet for å muliggjøre effektiv samhandling mellom AI-modeller og applikasjoner. I sammenheng med sanntids datastrømming tilbyr MCP en ramme for:

- Å bevare kontekst gjennom hele datapipelinen
- Standardisering av datautvekslingsformater
- Optimalisering av overføring av store datasett
- Forbedret kommunikasjon mellom modell til modell og modell til applikasjon

### Kjernekomponenter og arkitektur

MCP-arkitektur for sanntids streaming består av flere nøkkelkomponenter:

1. **Kontekstbehandlere**: Administrerer og opprettholder kontekstuell informasjon gjennom streaming-pipelinen
2. **Strømprosessorer**: Behandler innkommende datastrømmer ved hjelp av kontekstbevisste teknikker
3. **Protokolladaptere**: Konverterer mellom ulike streamingprotokoller samtidig som kontekst bevares
4. **Kontekstlager**: Effektiv lagring og henting av kontekstuell informasjon
5. **Streamingtilkoblinger**: Koblinger til ulike streamingplattformer (Kafka, Pulsar, Kinesis osv.)

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

### Hvordan MCP forbedrer sanntids datahåndtering

MCP løser tradisjonelle streamingutfordringer ved å tilby:

- **Kontekstuell integritet**: Opprettholde relasjoner mellom datapunkter gjennom hele pipelinen
- **Optimalisert overføring**: Redusere duplisering i datautveksling gjennom intelligent kontekststyring
- **Standardiserte grensesnitt**: Tilby konsistente API-er for streamingkomponenter
- **Redusert latens**: Minimere behandlingskostnader gjennom effektiv kontekstbehandling
- **Forbedret skalerbarhet**: Støtte horisontal skalering samtidig som kontekst bevares

## Integrasjon og implementering

Sanntids datastrømmingssystemer krever nøye arkitektonisk design og implementering for å opprettholde både ytelse og kontekstuell integritet. Modellkontekstprotokollen tilbyr en standardisert tilnærming for integrasjon av AI-modeller og streamingteknologier, som muliggjør mer avanserte, kontekstbevisste behandlingspipelines.

### Oversikt over MCP-integrasjon i streamingarkitekturer

Implementering av MCP i sanntids streamingmiljøer involverer flere viktige hensyn:

1. **Kontekstserialisering og transport**: MCP tilbyr effektive mekanismer for koding av kontekstuell informasjon i streaming datapakker, slik at essensiell kontekst følger dataene gjennom hele behandlingsrøret. Dette inkluderer standardiserte serialiseringsformater optimalisert for streamingtransport.

2. **Stateful strømbehandling**: MCP muliggjør mer intelligent stateful behandling ved å opprettholde konsistent kontekstrepresentasjon på tvers av behandlingsnoder. Dette er særlig verdifullt i distribuerte streamingarkitekturer der tilstandshåndtering tradisjonelt er utfordrende.

3. **Event-tid vs. behandlingstid**: MCP-implementasjoner i streaming må håndtere utfordringen med å skille mellom når hendelser skjedde og når de behandles. Protokollen kan inkludere tidsmessig kontekst som bevarer event-tid-semantikk.

4. **Backpressure-håndtering**: Ved å standardisere kontekstbehandling hjelper MCP med å håndtere backpressure i streaming, slik at komponenter kan kommunisere sin behandlingskapasitet og justere dataflyten deretter.

5. **Kontekstvinduer og aggregering**: MCP muliggjør mer avanserte vindusoperasjoner ved å tilby strukturerte representasjoner av tids- og relasjonskontekster, som gir mer meningsfulle aggregeringer på tvers av hendelsesstrømmer.

6. **Eksakt-én-gang behandling**: I streaming-systemer som krever eksakt-én-gang semantikk, kan MCP inkludere behandlingsmetadata for å hjelpe med sporing og verifisering av behandlingstilstand på tvers av distribuerte komponenter.

Implementeringen av MCP på tvers av ulike streamingteknologier skaper en enhetlig tilnærming til kontekststyring, reduserer behovet for skreddersydd integrasjonskode samtidig som systemets evne til å opprettholde meningsfull kontekst under dataflyt forbedres.

### MCP i ulike datastrømmingsrammeverk

Disse eksemplene følger gjeldende MCP-spesifikasjon som fokuserer på en JSON-RPC-basert protokoll med distinkte transportmekanismer. Koden viser hvordan du kan implementere egendefinerte transportlag som integrerer streamingplattformer som Kafka og Pulsar, samtidig som full kompatibilitet med MCP-protokollen opprettholdes.

Eksemplene er laget for å vise hvordan streamingplattformer kan integreres med MCP for å tilby sanntids databehandling samtidig som den kontekstbevisste kjernen i MCP bevares. Denne tilnærmingen sikrer at kodeeksemplene nøyaktig reflekterer gjeldende MCP-spesifikasjon per juni 2025.

MCP kan integreres med populære streamingrammeverk som:

#### Apache Kafka-integrasjon

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

#### Apache Pulsar-implementasjon

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

### Beste praksis for distribusjon

Ved implementering av MCP for sanntids streaming:

1. **Design for feiltoleranse**:
   - Implementer korrekt feilhåndtering
   - Bruk dead-letter køer for mislykkede meldinger
   - Design idempotente prosessorer

2. **Optimaliser for ytelse**:
   - Konfigurer passende buffere
   - Bruk batch-behandling der det er hensiktsmessig
   - Implementer backpressure-mekanismer

3. **Overvåk og observer**:
   - Følg med på strømprosesserings-metrikker
   - Overvåk kontekstspredning
   - Sett opp varsler for avvik

4. **Sikre strømmer**:
   - Krypter sensitiv data
   - Bruk autentisering og autorisasjon
   - Anvend riktige tilgangskontroller

### MCP i IoT og edge computing

MCP forbedrer IoT-strømming ved å:

- Bevare enhetskontekst gjennom hele behandlingsrøret
- Muliggjøre effektiv edge-til-cloud datastrømming
- Støtte sanntidsanalyse av IoT-datastrømmer
- Legge til rette for enhet-til-enhet kommunikasjon med kontekst

Eksempel: Smarte by-sensornettverk  
```
Sensors → Edge Gateways → MCP Stream Processors → Real-time Analytics → Automated Responses
```

### Rolle i finansielle transaksjoner og høyfrekvent handel

MCP gir betydelige fordeler for finansielle datastrømmer:

- Ekstremt lav latens i behandlingen av handelsbeslutninger
- Opprettholdelse av transaksjonskontekst gjennom hele prosessen
- Støtte for kompleks hendelsesbehandling med kontekstbevissthet
- Sikring av datakonsistens på tvers av distribuerte handelssystemer

### Forbedring av AI-drevet dataanalyse

MCP åpner nye muligheter for streaminganalyse:

- Sanntidstrening og inferens av modeller
- Kontinuerlig læring fra datastrømmer
- Kontekstbevisst funksjonsutvinning
- Flere modell-inferens-pipelines med bevart kontekst

## Fremtidige trender og innovasjoner

### Utvikling av MCP i sanntidsmiljøer

Fremover forventer vi at MCP vil utvikle seg for å møte:

- **Integrasjon med kvanteberegning**: Forberede streaming-systemer basert på kvante-teknologi
- **Edge-native behandling**: Flytte mer kontekstbevisst behandling til edge-enheter
- **Autonom strømstyring**: Selvoptimaliserende streaming-pipelines
- **Federert streaming**: Distribuert behandling samtidig som personvern ivaretas

### Potensielle teknologiske fremskritt

Nye teknologier som vil forme fremtidens MCP-streaming:

1. **AI-optimaliserte streamingprotokoller**: Skreddersydde protokoller for AI-arbeidsmengder
2. **Nevromorfisk beregning**: Hjerneinspirert databehandling for strømprosessering
3. **Serverløs streaming**: Hendelsesdrevet, skalerbar streaming uten infrastrukturadministrasjon
4. **Distribuerte kontekstlagre**: Globalt distribuerte, men svært konsistente kontekststyringsløsninger

## Praktiske øvelser

### Øvelse 1: Sette opp en grunnleggende MCP streamingpipeline

I denne øvelsen lærer du å:
- Konfigurere et grunnleggende MCP streamingmiljø
- Implementere kontekstbehandlere for strømprosessering
- Teste og validere kontekstbevaring

### Øvelse 2: Bygge et sanntids analyse-dashboard

Lag en komplett applikasjon som:
- Tar imot datastrømmer ved hjelp av MCP
- Behandler strømmen samtidig som kontekst opprettholdes
- Visualiserer resultater i sanntid

### Øvelse 3: Implementere kompleks hendelsesbehandling med MCP

Avansert øvelse som dekker:
- Mønsterdeteksjon i strømmer
- Kontekstuell korrelasjon på tvers av flere strømmer
- Generering av komplekse hendelser med bevart kontekst

## Ekstra ressurser

- [Model Context Protocol Specification](https://github.com/modelcontextprotocol) - Offisiell MCP-spesifikasjon og dokumentasjon
- [Apache Kafka Documentation](https://kafka.apache.org/documentation/) - Lær om Kafka for strømmebehandling
- [Apache Pulsar](https://pulsar.apache.org/) - Enhetlig meldings- og streamingplattform
- [Streaming Systems: The What, Where, When, and How of Large-Scale Data Processing](https://www.oreilly.com/library/view/streaming-systems/9781491983867/) - Omfattende bok om streamingarkitekturer
- [Microsoft Azure Event Hubs](https://learn.microsoft.com/azure/event-hubs/event-hubs-about) - Administrert event streaming-tjeneste
- [MLflow Documentation](https://mlflow.org/docs/latest/index.html) - For ML-modellsporing og distribusjon
- [Real-Time Analytics with Apache Storm](https://storm.apache.org/releases/current/index.html) - Behandlingsrammeverk for sanntidsberegning
- [Flink ML](https://nightlies.apache.org/flink/flink-ml-docs-master/) - Maskinlæringsbibliotek for Apache Flink
- [LangChain Documentation](https://python.langchain.com/docs/get_started/introduction) - Bygge applikasjoner med LLM-er

## Læringsutbytte

Ved å fullføre denne modulen vil du kunne:

- Forstå grunnleggende prinsipper for sanntids datastrømming og tilhørende utfordringer
- Forklare hvordan Modellkontekstprotokollen (MCP) forbedrer sanntids datastrømming
- Implementere MCP-baserte streamingløsninger ved bruk av populære rammeverk som Kafka og Pulsar
- Designe og distribuere feiltolerante, høyytelses streamingarkitekturer med MCP
- Anvende MCP-konsepter i IoT, finanshandel og AI-drevne analysebrukstilfeller
- Vurdere nye trender og fremtidige innovasjoner innen MCP-baserte streamingteknologier

## Hva nå

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det originale dokumentet på dets opprinnelige språk bør betraktes som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår fra bruk av denne oversettelsen.