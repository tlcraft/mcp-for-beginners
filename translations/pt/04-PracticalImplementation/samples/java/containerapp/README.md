<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e5ea5e7582f70008ea9bec3b3820f20a",
  "translation_date": "2025-05-17T14:25:27+00:00",
  "source_file": "04-PracticalImplementation/samples/java/containerapp/README.md",
  "language_code": "pt"
}
-->
## Arquitetura do Sistema

Este projeto demonstra uma aplicação web que utiliza verificação de segurança de conteúdo antes de passar solicitações de usuários para um serviço de calculadora via Model Context Protocol (MCP).

![Diagrama de Arquitetura do Sistema](../../../../../../translated_images/plant.84b061907411570c4d69e747b3f5569a0783a9b3e7b81a8e0ffee5a0a459f312.pt.png)

### Como Funciona

1. **Entrada do Usuário**: O usuário insere uma solicitação de cálculo na interface web
2. **Triagem de Segurança de Conteúdo (Entrada)**: A solicitação é analisada pela API de Segurança de Conteúdo da Azure
3. **Decisão de Segurança (Entrada)**:
   - Se o conteúdo for seguro (gravidade < 2 em todas as categorias), ele é encaminhado para a calculadora
   - Se o conteúdo for marcado como potencialmente prejudicial, o processo é interrompido e retorna um aviso
4. **Integração com a Calculadora**: Conteúdo seguro é processado pelo LangChain4j, que se comunica com o servidor de calculadora MCP
5. **Triagem de Segurança de Conteúdo (Saída)**: A resposta do bot é analisada pela API de Segurança de Conteúdo da Azure
6. **Decisão de Segurança (Saída)**:
   - Se a resposta do bot for segura, ela é exibida ao usuário
   - Se a resposta do bot for marcada como potencialmente prejudicial, ela é substituída por um aviso
7. **Resposta**: Resultados (se seguros) são exibidos ao usuário junto com ambas as análises de segurança

## Usando o Model Context Protocol (MCP) com Serviços de Calculadora

Este projeto demonstra como usar o Model Context Protocol (MCP) para chamar serviços de calculadora MCP a partir do LangChain4j. A implementação utiliza um servidor MCP local rodando na porta 8080 para fornecer operações de calculadora.

### Configurando o Serviço de Segurança de Conteúdo da Azure

Antes de usar os recursos de segurança de conteúdo, você precisa criar um recurso de serviço de Segurança de Conteúdo da Azure:

1. Acesse o [Portal Azure](https://portal.azure.com)
2. Clique em "Criar um recurso" e procure por "Segurança de Conteúdo"
3. Selecione "Segurança de Conteúdo" e clique em "Criar"
4. Insira um nome exclusivo para seu recurso
5. Selecione sua assinatura e grupo de recursos (ou crie um novo)
6. Escolha uma região suportada (verifique a [disponibilidade de região](https://azure.microsoft.com/en-us/global-infrastructure/services/?products=cognitive-services) para detalhes)
7. Selecione um nível de preço apropriado
8. Clique em "Criar" para implantar o recurso
9. Após a conclusão da implantação, clique em "Ir para o recurso"
10. No painel à esquerda, em "Gerenciamento de Recursos", selecione "Chaves e Endpoint"
11. Copie uma das chaves e a URL do endpoint para uso na próxima etapa

### Configurando Variáveis de Ambiente

Defina a variável de ambiente `GITHUB_TOKEN` para autenticação de modelos do GitHub:
```sh
export GITHUB_TOKEN=<your_github_token>
```

Para recursos de segurança de conteúdo, defina:
```sh
export CONTENT_SAFETY_ENDPOINT=<your_content_safety_endpoint>
export CONTENT_SAFETY_KEY=<your_content_safety_key>
```

Essas variáveis de ambiente são usadas pela aplicação para autenticar com o serviço de Segurança de Conteúdo da Azure. Se essas variáveis não estiverem definidas, a aplicação usará valores de espaço reservado para fins de demonstração, mas os recursos de segurança de conteúdo não funcionarão corretamente.

### Iniciando o Servidor MCP da Calculadora

Antes de executar o cliente, você precisa iniciar o servidor MCP da calculadora no modo SSE em localhost:8080.

## Descrição do Projeto

Este projeto demonstra a integração do Model Context Protocol (MCP) com LangChain4j para chamar serviços de calculadora. Os principais recursos incluem:

- Uso do MCP para conectar-se a um serviço de calculadora para operações matemáticas básicas
- Verificação de segurança de conteúdo em duas camadas, tanto nas solicitações dos usuários quanto nas respostas do bot
- Integração com o modelo gpt-4.1-nano do GitHub via LangChain4j
- Uso de Eventos Enviados pelo Servidor (SSE) para transporte MCP

## Integração de Segurança de Conteúdo

O projeto inclui recursos abrangentes de segurança de conteúdo para garantir que tanto as entradas dos usuários quanto as respostas do sistema estejam livres de conteúdo prejudicial:

1. **Triagem de Entrada**: Todas as solicitações dos usuários são analisadas para categorias de conteúdo prejudicial, como discurso de ódio, violência, autoagressão e conteúdo sexual antes do processamento.

2. **Triagem de Saída**: Mesmo ao usar modelos potencialmente sem censura, o sistema verifica todas as respostas geradas pelos mesmos filtros de segurança de conteúdo antes de exibi-las ao usuário.

Essa abordagem em duas camadas garante que o sistema permaneça seguro, independentemente de qual modelo de IA esteja sendo usado, protegendo os usuários tanto de entradas prejudiciais quanto de saídas potencialmente problemáticas geradas pela IA.

## Cliente Web

A aplicação inclui uma interface web amigável que permite aos usuários interagir com o sistema de Calculadora de Segurança de Conteúdo:

### Recursos da Interface Web

- Formulário simples e intuitivo para inserir solicitações de cálculo
- Validação de segurança de conteúdo em duas camadas (entrada e saída)
- Feedback em tempo real sobre a segurança das solicitações e respostas
- Indicadores de segurança com código de cores para fácil interpretação
- Design limpo e responsivo que funciona em vários dispositivos
- Exemplos de solicitações seguras para guiar os usuários

### Usando o Cliente Web

1. Inicie a aplicação:
   ```sh
   mvn spring-boot:run
   ```

2. Abra seu navegador e navegue para `http://localhost:8087`

3. Insira uma solicitação de cálculo na área de texto fornecida (por exemplo, "Calcule a soma de 24.5 e 17.3")

4. Clique em "Enviar" para processar sua solicitação

5. Veja os resultados, que incluirão:
   - Análise de segurança de conteúdo da sua solicitação
   - O resultado calculado (se a solicitação for segura)
   - Análise de segurança de conteúdo da resposta do bot
   - Quaisquer avisos de segurança se a entrada ou saída for marcada

O cliente web lida automaticamente com ambos os processos de verificação de segurança de conteúdo, garantindo que todas as interações sejam seguras e apropriadas, independentemente de qual modelo de IA esteja sendo usado.

**Aviso Legal**:  
Este documento foi traduzido usando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automatizadas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autoritária. Para informações críticas, recomenda-se a tradução humana profissional. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações errôneas decorrentes do uso desta tradução.