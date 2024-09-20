import { useCookie, useRuntimeConfig } from '#app';

interface LoginResponse {
  token: string;
}

export function useAuth() {
  const config = useRuntimeConfig();
  const token = useCookie<string>('token');

  // Register
  const register = async (email: string, username:string, password: string) => {
    const response = await fetch(`${config.public.API_BASE_URL}/account/register`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({ email, username, password }),
    });

    if (!response.ok) {
      const errorData = await response.json();
      throw new Error(errorData.message || 'Register failed');
    }

    const data: LoginResponse = await response.json();
    
    token.value = data.token;
    return data;
  };

  // Logowanie
  const login = async (email: string, password: string) => {
    try {
    console.log( JSON.stringify({ email, password }));
      const data = await $fetch<LoginResponse>(`${config.public.API_BASE_URL}/account/login`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({ email, password }),
      });
     
      token.value = data.token;
      return data;
    } catch (error) {
      // W przypadku błędu, logujemy i rzucamy nowy wyjątek
      console.error('Login error:', error);
      throw new Error('Login failed');
    }
  };

  const logout = () => {
    token.value = '';
  };

  const isAuthenticated = () => {
    return !!token.value;
  };

  return {
    register,
    login,
    logout,
    isAuthenticated,
  };
}
