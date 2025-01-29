# Redis

## O que é o Redis?

O Redis é um armazenamento de estrutura de dados de chave-valor de código aberto e na memória. O Redis oferece um conjunto de estruturas versáteis de dados na memória que permite a fácil criação de várias aplicações personalizadas. Escrito em código C, ele é otimizado e compatível com várias de linguagens de desenvolvimento. Redis é um acrônimo de Remote Dictionary Server (servidor de dicionário remoto).

## Benefícios

Alguns dos principais benefício do Redis são:

### Desempenho muito rápido

Todos os dados do Redis residem na memória principal do ser servidor, em contraste com a maioria dos sistemas de gerenciamento de banco de dados que armazenam dados em disco ou SSDs. Ao eliminar a necessidade de acessar discos, bancos de dados na memória, como o Redis, evitam atrasos de tempo de busca e podem acessar dados com algoritmos mais simples que usam menos instruções de CPU. Operações comuns exigem menos do que 10 milissegundos para serem executadas

### Estrutura de dados na memória

O Redis permite que os usuários armazenem chaves que fazem o mapeamento para vários tipos de dados. O tipo de dados fundamental é uma string, que pode ser em formato de dados de texto ou binários e ter no máximo 512 MB. O Redis também é compatível com listas de strings na ordem em que foram adicionadas, conjuntos de strings não ordenadas, conjuntos classificados ordenados de acordo com uma pontuação, hashes que armazenam uma lista de campos e valor e HyperLogLogs para contar os itens exclusivos de um conjunto de dados. Praticamente qualquer tipo de dado pode ser armazenado na memória usando o Redis

### Versatilidade e facilidade de uso

O Redis é disponibilizado com várias ferramentas que tornam o desenvolvimento e as operações mais rápidas e fáceis, inclusive o PUB/SUB para publicar mensagens nos canais que são entregues para os assinantes, o que é ótimo para sistemas de mensagens e chat, as chaves com TTL podem ter um tempo de vida útil determinado, após a qual elas se autoexcluem, o que ajuda a evitar sobrecarregar o banco de dados com itens desnecessários, os contadores atômicos garantem que condições de corrida não criem resultados incompatíveis, além da Lua, uma linguagem de script potente, porém leve.

### Replicação e persistência

O Redis emprega uma arquitetura no estilo mestre/subordinado e é compatível com a replicação assíncrona em que os dados podem ser replicados para vários servidores subordinados. Isso pode disponibilizar desempenho de leitura melhorado (à medida que as solicitações podem ser divididas entre os servidores) e recuperação quando o servidor primário passar por uma interrupção.

Para disponibilizar durabilidade, o Redis oferece compatibilidade com **snapshots** point-in-time (copiando o conjunto de dados do Redis no disco) e criando um **Append Only File** (AOF) para armazenar cada alteração de dados no disco conforme elas vão sendo gravadas. Os dois métodos permitem a restauração rápida dos dados do Redis no caso de uma interrupção.

## Principais casos de uso

O Redis é comumente usado para lidar com cache, gerenciamento de sessões, PUB/SUB e classificações. Por conta da sua velocidade e facilidade de uso, o Redis é uma escolha em alta demanda para aplicações web e móveis, como também de jogos, tecnologia de anúncios e IoT, que exigem melhor desempenho do mercado.

### **Armazenamento em cache**

O Redis inserido na "frente" de outro banco de dados cria um cache na memória com excelente desempenho para diminuir a latência de acesso, aumentar o throughput e facilitar a descarga de um banco de dados relacional ou NoSQL.

### **Gerenciamento de sessões**

O Redis é altamente indicado para tarefas de gerenciamento de sessões. Basta usar o Redis como um armazenamento de chave-valor com o tempo de vida (TTL) correto nas chaves de sessão para gerenciar suas informações de sessão. O gerenciamento de sessões é comumente exigido para aplicações on-line, como jogos, sites de comércio eletrônico e plataformas de mídia social.

### **Classificações em tempo real**

Ao usar a estrutura de dados Sorted Set do Redis, os elementos são mantidos em uma lista, classificada de acordo com suas pontuações. Isso facilita a criação de classificações dinâmicas para mostrar quem está vencendo o jogo ou publicando as mensagens mais curtidas ou qualquer outra coisa que demonstre quem está na liderança.

### **Limite de taxa**

O Redis pode calcular e, quando necessário, acelerar a taxa dos eventos. Ao usar um contador do Redis associado a uma chave de API do cliente, você poderá contar o número de solicitações de acesso dentro de um determinado período e tomar as ações necessárias, caso um limite seja excedido. Os limitadores de taxa são usados comumente para limitar o número de publicações em um fórum, limitar a utilização de recursos e conter o impacto de remetentes de spam.

### **Filas**

A estrutura de dados Redis List facilita implementar uma fila leve e persistente. As listas oferecem operações atômicas, além de recursos de bloqueio, tornando-as adequadas para várias aplicações que exigem um agente de mensagens confiável ou uma lista circular.

### **Chat e sistema de mensagens**

O Redis é compatível com PUB/SUB padrão com correspondência de padrões. Isso permite que o Redis seja compatível com salas de chat de alto desempenho, streams de comentários em tempo real e intercomunicações do servidor. Você também pode usar o PUB/SUB para ativar ações com base em eventos publicados.
