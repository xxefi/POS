import { useState } from "react";
import ImagePanel from "../components/cards/auth/card_login/imagePanel";
import LoginForm from "../components/cards/auth/card_login/loginForm";
import Clock from "../components/cards/auth/card_login/clock";

export default function Login() {
  const [step, setStep] = useState<number>(1);
  const [formData, setFormData] = useState<{
    brand: string;
    password: string;
    pinCode: string;
  }>({
    brand: "",
    password: "",
    pinCode: "",
  });

  const handleChange = (value: any) => {
    setFormData((prev) => ({
      ...prev,
      ...value,
    }));
  };

  const handlePinCodeInput = (digit: string) => {
    if (formData.pinCode.length < 4) {
      setFormData((prev) => ({
        ...prev,
        pinCode: prev.pinCode + digit,
      }));
    }
  };

  const handlePinCodeDelete = () => {
    setFormData((prev) => ({
      ...prev,
      pinCode: prev.pinCode.slice(0, -1),
    }));
  };

  const handleSubmit = (checkStatus: boolean) => {
    if (checkStatus) {
      if (step === 1) {
        setStep(2);
      } else if (step === 2) {
        setStep(3);
      } else if (step === 3) {
        console.log("Форма успешно отправлена:", formData);
      }
    }
  };

  return (
    <div className="flex h-screen bg-gradient-to-r from-blue-200 to-white">
      <ImagePanel />
      <div className="flex w-1/2 items-center justify-center">
        <LoginForm
          step={step}
          formData={formData}
          handleChange={handleChange}
          handlePinCodeInput={handlePinCodeInput}
          handlePinCodeDelete={handlePinCodeDelete}
          handleSubmit={handleSubmit}
        />
      </div>
      <Clock />
    </div>
  );
}
