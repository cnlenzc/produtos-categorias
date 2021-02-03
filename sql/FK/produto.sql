ALTER TABLE `produto` ADD CONSTRAINT `produto_FK_categoria` FOREIGN KEY (`categoriaid`) REFERENCES `categoria` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT;
