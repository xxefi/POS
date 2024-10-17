export interface OrderItem {
  id: number;
  name: string;
  description: string;
  qty: number;
  price: number;
  total: number;
}

export interface MenuItem {
  id: number;
  name: string;
  price: number;
  image: string;
}
