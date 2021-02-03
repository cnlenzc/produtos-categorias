CREATE TABLE `produto` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `descricao` varchar(60) NOT NULL,
  `unidade` varchar(2) DEFAULT NULL,
  `valor` decimal(18,2) DEFAULT NULL,
  `datahora_cadastro` datetime DEFAULT NULL,
  `categoriaid` bigint DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `produto_descricao_IDX` (`descricao`) USING BTREE,
  KEY `produto_FK_categoria` (`categoriaid`)
);
