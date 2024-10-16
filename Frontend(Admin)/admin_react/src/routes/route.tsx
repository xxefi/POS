import Layout from "../layouts/layout.tsx";
import Dashboard from "../pages/statistics/dashboard.tsx";
import Sales from "../pages/statistics/sales.tsx";
import Reports from "../pages/statistics/reports.tsx";
import Receipts from "../pages/sale/receipts.tsx";
import OrderNotifications from "../pages/sale/orderNotifications.tsx";
import ProductReturn from "../pages/sale/productReturn.tsx";
import History from "../pages/statistics/history.tsx";
import PaymentMethods from "../pages/sale/paymentMethods.tsx";
import SalesMethods from "../pages/sale/salesMethods.tsx";
import Accounts from "../pages/finances/accounts.tsx";
import Categories from "../pages/finances/categories.tsx";
import Transactions from "../pages/finances/transactions.tsx";
import Payroll from "../pages/finances/payroll.tsx";
import CashFlow from "../pages/finances/cashflow.tsx";
import Products from "../pages/menu/products.tsx";
import CategoriesMenu from "../pages/menu/categoriesMenu.tsx";
import MenuRearrangement from "../pages/menu/menuRearrangement.tsx";
import Customers from "../pages/marketing/customers.tsx";
import CustomerGroup from "../pages/marketing/customerGroup.tsx";
import Reviews from "../pages/marketing/reviews.tsx";
import Users from "../pages/staff/users.tsx";
import Roles from "../pages/staff/roles.tsx";
import Terminal from "../pages/access/terminal.tsx";
import General from "../pages/settings/general.tsx";
import SettingsTerminal from "../pages/settings/terminal.tsx";
import Taxes from "../pages/settings/taxes.tsx";
import SettingsReceipts from "../pages/settings/receipts.tsx";
import Subscriptions from "../pages/settings/subscriptions.tsx";
import TableManagement from "../pages/settings/tableManagement.tsx";
import Login from "../components/auth/login.tsx";
import NotFound from "../routes/notfound.tsx";
import { RouteConfig } from "../components/interfaces/route.config.ts";
import PaymentMethodCreate from "../components/cards/sale/card_paymentMethods/paymentMethodCreate.tsx";
import SaleMethodCreate from "../components/cards/sale/card_saleMethods/saleMethodCreate.tsx";
import PaymentMethodsLayout from "../layouts/paymentLayout.tsx";
import SaleMethodsLayout from "../layouts/saleLayout.tsx";
import AccountLayout from "../layouts/accountLayout.tsx";
import AccountCreate from "../components/cards/financies/card_accounts/accountCreate.tsx";
import CategoryLayout from "../layouts/categoryLayout.tsx";
import CategoryCreate from "../components/cards/financies/card_categories/categoryCreate.tsx";
import CategoryMenuCreate from "../components/cards/menu/card_categoriesMenu/categoryMenuCreate.tsx";
import TransactionLayout from "../layouts/transactionLayout.tsx";
import TransactionCreate from "../components/cards/financies/card_transactions/transactionCreate.tsx";
import ProductLayout from "../layouts/productLayout.tsx";
import ProductCreate from "../components/cards/menu/card_products/productCreate.tsx";
import CategoryMenuLayout from "../layouts/categoryMenuLayout.tsx";
import CustomerLayout from "../layouts/customerLayout.tsx";
import CustomerCreate from "../components/cards/marketing/card_customers/customerCreate.tsx";
import CustomerGroupLayout from "../layouts/customerGroupLayout.tsx";
import CustomerGroupCreate from "../components/cards/marketing/card_customerGroup/customerGroupCreate.tsx";
import UserLayout from "../layouts/userLayout.tsx";
import UserCreate from "../components/cards/staff/card_user/userCreate.tsx";
import RoleLayout from "../layouts/roleLayout.tsx";
import RoleCreate from "../components/cards/staff/card_roles/roleCreate.tsx";
import TaxeLayout from "../layouts/taxeLayout.tsx";
import TaxeCreate from "../components/cards/settings/card_taxes/taxeCreate.tsx";

export const routes: RouteConfig[] = [
  {
    path: "/",
    element: <Layout />,
    children: [
      {
        path: "statistics",
        element: null,
        children: [
          { path: "dashboard", element: <Dashboard /> },
          { path: "sales", element: <Sales /> },
          { path: "reports", element: <Reports /> },
          { path: "history", element: <History /> },
        ],
      },
      {
        path: "sale",
        element: null,
        children: [
          { path: "receipts", element: <Receipts /> },
          { path: "orderNotifications", element: <OrderNotifications /> },
          { path: "productReturn", element: <ProductReturn /> },
          {
            path: "paymentMethods",
            element: <PaymentMethodsLayout />,
            children: [
              { path: "paymentMethods", element: <PaymentMethods /> },
              { path: "create", element: <PaymentMethodCreate /> },
            ],
          },
          {
            path: "salesMethods",
            element: <SaleMethodsLayout />,
            children: [
              { path: "salesMethods", element: <SalesMethods /> },
              { path: "create", element: <SaleMethodCreate /> },
            ],
          },
        ],
      },
      {
        path: "finances",
        element: null,
        children: [
          {
            path: "accounts",
            element: <AccountLayout />,
            children: [
              { path: "accounts", element: <Accounts /> },
              { path: "create", element: <AccountCreate /> },
            ],
          },
          {
            path: "categories",
            element: <CategoryLayout />,
            children: [
              { path: "categories", element: <Categories /> },
              { path: "create", element: <CategoryCreate /> },
            ],
          },
          {
            path: "transactions",
            element: <TransactionLayout />,
            children: [
              { path: "transactions", element: <Transactions /> },
              { path: "create", element: <TransactionCreate /> },
            ],
          },
          { path: "payroll", element: <Payroll /> },
          { path: "cashFlow", element: <CashFlow /> },
        ],
      },
      {
        path: "menu",
        element: null,
        children: [
          {
            path: "products",
            element: <ProductLayout />,
            children: [
              { path: "products", element: <Products /> },
              { path: "create", element: <ProductCreate /> },
            ],
          },
          {
            path: "categories",
            element: <CategoryMenuLayout />,
            children: [
              { path: "categories", element: <CategoriesMenu /> },
              { path: "create", element: <CategoryMenuCreate /> },
            ],
          },
          { path: "menuRearrangement", element: <MenuRearrangement /> },
        ],
      },
      {
        path: "marketing",
        element: null,
        children: [
          {
            path: "customers",
            element: <CustomerLayout />,
            children: [
              { path: "customers", element: <Customers /> },
              { path: "create", element: <CustomerCreate /> },
            ],
          },
          {
            path: "customerGroup",
            element: <CustomerGroupLayout />,
            children: [
              { path: "customerGroup", element: <CustomerGroup /> },
              { path: "create", element: <CustomerGroupCreate /> },
            ],
          },
          { path: "reviews", element: <Reviews /> },
        ],
      },
      {
        path: "staff",
        element: null,
        children: [
          {
            path: "users",
            element: <UserLayout />,
            children: [
              { path: "users", element: <Users /> },
              { path: "create", element: <UserCreate /> },
            ],
          },
          {
            path: "roles",
            element: <RoleLayout />,
            children: [
              { path: "role", element: <Roles /> },
              { path: "create", element: <RoleCreate /> },
            ],
          },
        ],
      },
      {
        path: "access",
        element: null,
        children: [{ path: "terminal", element: <Terminal /> }],
      },
      {
        path: "settings",
        element: null,
        children: [
          { path: "general", element: <General /> },
          { path: "terminal", element: <SettingsTerminal /> },
          {
            path: "taxes",
            element: <TaxeLayout />,
            children: [
              { path: "taxes", element: <Taxes /> },
              { path: "create", element: <TaxeCreate /> },
            ],
          },
          { path: "receipts", element: <SettingsReceipts /> },
          { path: "subscriptions", element: <Subscriptions /> },
          { path: "tableManagement", element: <TableManagement /> },
        ],
      },
    ],
  },
  {
    path: "login",
    element: <Login />,
  },
  {
    path: "*",
    element: <NotFound />,
  },
];
