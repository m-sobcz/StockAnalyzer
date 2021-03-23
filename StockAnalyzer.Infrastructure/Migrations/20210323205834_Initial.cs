using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockAnalyzer.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Balance",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoncurrentAssets = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IntangibleAssets = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Goodwill = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Property = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RightToUseAssets = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NoncurrentReceivables = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NoncurrInvestments = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtherNoncurrentAssets = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentAssets = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Inventory = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentReceivables = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentInvestments = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cash = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtherCurrentAssets = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AssetsForSale = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAssets = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Capital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ShareCapital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OwnShares = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Reserve = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NonshareCapital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NoncurrentLiabilities = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NoncurrentTradeLiabilities = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NoncurrentBorrowings = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NoncurrentObligations = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NoncurrentLeasing = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NoncurrentOtherLiabilities = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentLiabilities = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentTradePayablesv = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentBorrowings = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentObligations = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentLeasing = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentOtherLiabilities = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Reckoning = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalEquityAndLiabilities = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CashWithCentralBank = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LoansToBanks = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FinAssetsForTrading = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HeldFinancialAssets = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LoansToCustomers = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtherFinAssets = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvestInSubsidiaries = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxAssets = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtherAssets = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LiabilitiesToCentralBank = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LiabilitiesToBanks = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HeldFinancialLiabilities = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FinLiabilitiesForTrading = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LiabilitiesToCustomers = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DebtSecurities = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubodinatedLiabilities = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxLiabilities = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtherLiabilities = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalLiabilities = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OwnCapital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SharePremium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RevaluationReserves = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RetainedReserves = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    YearProfit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NonControlProfit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalCapital = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cashflow",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperatingCashflow = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amortization = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvestingCashflow = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Capex = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FinancingCashflow = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ShareCapitalCash = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Dividend = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockBuyback = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LeasePayments = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetCashflow = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FCM = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cashflow", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Income",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Revenues = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostOfSales = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DistributionExpenses = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AdministrativExpenses = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrossProfit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtherOperatingIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EBIT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtherOperatingCosts = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FinanceIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FinanceCosts = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtherIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetGrossProfit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExtraordinarProfit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BeforeTaxProfit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscontinuedProfit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetProfit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ShareholderNetProfit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EBITDA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InterestIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IntrestExpense = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetIntrestIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FeeIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FeeExpense = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetFeeExpense = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DividendIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RealisedGains = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetOtherFinIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetOtherOperatingIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImpairmentLosses = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AdministrationCosts = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetOtherOperatingCosts = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetoperatingProfit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RelatedIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Income", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Period",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Quarter = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Period", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ticker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OpeningPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Volume = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Turnover = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UpdateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statement",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeriodId = table.Column<long>(type: "bigint", nullable: true),
                    BalanceId = table.Column<long>(type: "bigint", nullable: true),
                    IncomeId = table.Column<long>(type: "bigint", nullable: true),
                    CashflowId = table.Column<long>(type: "bigint", nullable: true),
                    StockId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statement_Balance_BalanceId",
                        column: x => x.BalanceId,
                        principalTable: "Balance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Statement_Cashflow_CashflowId",
                        column: x => x.CashflowId,
                        principalTable: "Cashflow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Statement_Income_IncomeId",
                        column: x => x.IncomeId,
                        principalTable: "Income",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Statement_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Statement_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockIndex",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StockId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockIndex", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockIndex_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Statement_BalanceId",
                table: "Statement",
                column: "BalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Statement_CashflowId",
                table: "Statement",
                column: "CashflowId");

            migrationBuilder.CreateIndex(
                name: "IX_Statement_IncomeId",
                table: "Statement",
                column: "IncomeId");

            migrationBuilder.CreateIndex(
                name: "IX_Statement_PeriodId",
                table: "Statement",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Statement_StockId",
                table: "Statement",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_StockIndex_StockId",
                table: "StockIndex",
                column: "StockId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Statement");

            migrationBuilder.DropTable(
                name: "StockIndex");

            migrationBuilder.DropTable(
                name: "Balance");

            migrationBuilder.DropTable(
                name: "Cashflow");

            migrationBuilder.DropTable(
                name: "Income");

            migrationBuilder.DropTable(
                name: "Period");

            migrationBuilder.DropTable(
                name: "Stocks");
        }
    }
}
