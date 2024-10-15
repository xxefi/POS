export interface ButtonData {
  label: string;
  isActive: boolean;
}

export interface ReportData {
  id: number;
  name: string;
  type: string;
  category: string;
  count: number;
  price: number;
  revenue: number;
  profit: number;
}

export interface HistoryData {
  receiptId: number;
  createdAt: string;
  terminal: string;
  receiptOperations: string;
  price: number;
}

export interface ReceiptData {
  receiptId: number;
  staff: string;
  createdAt: string;
  closedAt: string;
  terminal: string;
  table: string;
  subtotal: number;
}

export interface OrderNotificationsData {
  id: number;
  createdAt: string;
  integration: string;
  acceptedBy: string;
  terminal: string;
  receiptId: number;
  integrationStatus: boolean;
  status: boolean;
}

export interface ProductReturnData {
  id: number;
  operationTime: string;
  products: string;
  storage: string;
  receipt: string;
  waiter: string;
  terminal: string;
  customer: string;
  amount: number;
  paymentMethod: string;
}

export interface PaymentMethodData {
  id: number;
  name: string;
  account: string;
  status: boolean;
}

export interface SaleMethodData {
  id: number;
  name: string;
  paymentMethod: string;
  status: boolean;
}

export interface AccountData {
  id: number;
  name: string;
  description: string;
  type: string;
  amount: number;
}

export interface CategoryData {
  id: number;
  name: string;
  type: string;
  status: boolean;
  count: number;
}

export interface TransactionData {
  id: number;
  operationTime: string;
  createdAt: string;
  transactedBy: string;
  category: string;
  reference: string;
  description: string;
  paymentMethod: string;
  amount: number;
  account: string;
  type: string;
}

export interface PayrollData {
  id: number;
  username: string;
  role: string;
  totalPayment: number;
  salary: number;
  paidAmount: number;
}

export interface ProductData {
  id: number;
  name: string;
  status: boolean;
  gift: boolean;
  type: string;
  category: string;
  price: number;
}

export interface CategoryMenuData {
  id: number;
  name: string;
  status: boolean;
  count: number;
}

export interface CustomerData {
  id: number;
  name: string;
  email: string;
  group: string;
  phone: number;
  address: string;
  balance: number;
  dateOfBirth: string;
  gender: string;
  code: number;
  totalReceipts: number;
}

export interface CustomerGroupData {
  id: number;
  name: string;
  discount: number;
  balance: number;
}

export interface ReviewsData {
  id: number;
  type: string;
  fullName: string;
  service: number;
  food: number;
  delivery: number;
}

export interface UsersData {
  id: number;
  username: string;
  role: string;
  salary: number;
  email: string;
  phone: number;
  pin: number;
  code: number;
  lastLogin: string;
}

export interface RoleData {
  id: number;
  title: string;
  webAccess: boolean;
  terminalAccess: boolean;
  seller: boolean;
  courier: boolean;
}

export interface TerminalData {
  id: number;
  name: string;
  password: string;
  deviceType: string;
  status: boolean;
  receiveNotifications: boolean;
  online: boolean;
}

export interface GeneralSettingsData {
  brandName: string;
  tin: string;
  wifiName: string;
  wifiPassword: string;
  cashRegister: string;
  timezone: string;
  language: string;
  currency: string;
  googleMapsUrl: string;
  city: string;
  zip: string;
  address: string;
  phone: string;
  socialNetworks: string;
  workingHours: string;
}
