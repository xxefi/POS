export interface FinancesItem {
  to: string;
  label: string;
}

export const financesItem: FinancesItem[] = [
  { to: "/finances/accounts", label: "accounts" },
  { to: "/finances/categories", label: "categories" },
  { to: "/finances/transactions", label: "transactions" },
  { to: "/finances/payroll", label: "payroll" },
  { to: "/finances/cashflow", label: "cashflow" },
];
