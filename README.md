# una-sdm-lista-14

## Impacto da Latência no Endpoint de Estoque Regional
O endpoint `api/intelligence/estoque-regional` simula uma latência de 2 segundos para representar a consulta a um servidor central de logística. Em um cenário real, essa latência pode impactar negativamente a experiência do franqueado, especialmente ao fechar um pedido em um tablet na frente do cliente, pois aumenta o tempo de resposta e pode gerar insatisfação ou desistência da compra.

## Race Condition e Locking
Em datas como a Páscoa, milhares de pedidos são feitos simultaneamente. Se dois franqueados tentarem comprar o último lote de Trufas ao mesmo tempo, pode ocorrer uma condição de corrida (race condition), onde ambos acreditam que o produto está disponível. Para evitar isso, utiliza-se o bloqueio de banco de dados (locking), garantindo que apenas uma transação possa reservar ou vender o lote por vez, evitando vendas duplicadas e inconsistências no estoque.