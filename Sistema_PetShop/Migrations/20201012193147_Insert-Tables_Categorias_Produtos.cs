using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema_PetShop.Migrations
{
    public partial class InsertTables_Categorias_Produtos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(Nome, Descricao, ImagemCategoria) VALUES('Alimentação','Alimentação rica em componetes nutritivos garantindo bem estar dos animais.', 'https://photos.google.com/photo/AF1QipOyK1lhVh5E15ysuj1YAcgioOsaaRZdponFTzl4')");
            migrationBuilder.Sql("INSERT INTO Categorias(Nome, Descricao, ImagemCategoria) VALUES('Higiene','Linhas de produtos para higiente do seu Pet de dos melhores fabricantes', 'https://photos.google.com/photo/AF1QipMxfNzRuXdN6UmiJX2nwj1TlaGNKnuWlsxMhywa')");
            migrationBuilder.Sql("INSERT INTO Categorias(Nome, Descricao, ImagemCategoria) VALUES('Entretenimento','Itens especias para a alegria do seu Pet.', 'https://photos.google.com/photo/AF1QipM5YU4iwuYoU8c1syH0Zc1jgaMKzVJ-LvZutYmF')");
            migrationBuilder.Sql("INSERT INTO Categorias(Nome, Descricao, ImagemCategoria) VALUES('Medicação','Cuide da saude do seu Pet com os melhores medicamentos conceituados.', 'https://photos.google.com/photo/AF1QipPZ_GXfsfCaa0KOyC8_hDTrgwTckQeD14r6Mz5W')");

            migrationBuilder.Sql("INSERT INTO Produtos(DescricaoCurta, DescricaoDetalhada, Peso, Fabricante, Validade, Preco, CategoriaId) " +
                "VALUES('Ração DogBom - cãos filhotes sabor frango e arroz', 'Ração repleta de vitaminas e os melhores nitrientes','3', 'DogBom', '2021/01/01', '42.90', (SELECT CategoriaId FROM Categorias WHERE Nome = 'Alimentação'))");

            migrationBuilder.Sql("INSERT INTO Produtos(DescricaoCurta, DescricaoDetalhada, Peso, Fabricante, Validade, Preco, CategoriaId) " +
                "VALUES('Ração Úmida - cãos medium Adulto', 'Ração para cães de porte médio 12 a 5 anos de idade', '2', 'SuperRação', '2021/01/01', '29.99', (SELECT CategoriaId FROM Categorias WHERE Nome = 'Alimentação'))");

            migrationBuilder.Sql("INSERT INTO Produtos(DescricaoCurta, DescricaoDetalhada, Peso, Fabricante, Validade, Preco, CategoriaId) " +
                "VALUES('Ração Úmida - cãos pequenos', 'Ração para cães de pequeno porte até 1 ano de idade', '85', 'SuperRação', '2021/01/01', '9.29', (SELECT CategoriaId FROM Categorias WHERE Nome = 'Alimentação'))");

            migrationBuilder.Sql("INSERT INTO Produtos(DescricaoCurta, DescricaoDetalhada, Peso,Fabricante, Validade, Preco, CategoriaId) " +
                "VALUES('Ração Seca - cães adultos', 'Ração para cães adultos a partir de 7 anos de idade', '15', 'MaxCão', '2021/01/01', '229.99', (SELECT CategoriaId FROM Categorias WHERE Nome = 'Alimentação'))");

            migrationBuilder.Sql("INSERT INTO Produtos(DescricaoCurta, DescricaoDetalhada, Peso, Fabricante, Validade, Preco, CategoriaId) " +
                "VALUES('Ração Prescrita - cães Médios e Adultos', 'Ração para cães rica em vitaminas minerais e proteinas', '7.5', 'DogSpert', '2021/01/01', '119.99', (SELECT CategoriaId FROM Categorias WHERE Nome = 'Alimentação'))");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
            migrationBuilder.Sql("DELETE FROM Produtos");
        }
    }
}
