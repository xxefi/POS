export interface FormData {
  brand: string;
  password: string;
  pinCode: string;
}

export interface StepProps {
  formData: FormData;
  handleChange: (value: Partial<FormData>) => void;
}

export interface PinCodeProps {
  formData: {
    pinCode: string;
  };
  handlePinCodeInput: (digit: string) => void;
  handlePinCodeDelete: () => void;
}

export interface LoginProps {
  onSubmit: (formData: FormData) => void;
  step: number;
  setStep: (step: number) => void;
  formData: FormData;
  handleChange: (value: Partial<FormData>) => void;
}

export interface LoginFormProps {
  step: number;
  formData: FormData;
  handleChange: (value: Partial<FormData>) => void;
  handlePinCodeInput: (digit: string) => void;
  handlePinCodeDelete: () => void;
  handleSubmit: (checkStatus: boolean) => void;
}

export interface BrandInputProps {
  formData: {
    brand: string;
  };
  handleChange: (value: Partial<FormData>) => void;
}

export interface PasswordInputProps {
  formData: {
    password: string;
  };
  handleChange: (value: Partial<FormData>) => void;
}

export interface PinCodeInputProps {
  formData: {
    pinCode: string;
  };
  handlePinCodeInput: (digit: string) => void;
  handlePinCodeDelete: () => void;
}
