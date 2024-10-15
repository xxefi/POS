export interface LoginState {
  brand: string;
  loading: boolean;
  email: string;
  password: string;
  error: string;
  isAuthenticated: boolean;
  currentDateTime: string;
}
