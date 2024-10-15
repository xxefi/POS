import { Outlet, useLocation } from "react-router-dom";
import PaymentMethods from "../pages/sale/paymentMethods";

export default function PaymentMethodsLayout() {
  const location = useLocation();
  const isPaymentMethodsRoute = location.pathname === "/sale/paymentMethods";

  return isPaymentMethodsRoute ? <PaymentMethods/> : <Outlet/>
}
