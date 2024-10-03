import { useCookie, useRuntimeConfig } from "#app";
import type { Login, User } from "~/common/models";

export function useAuth() {
  const config = useRuntimeConfig();
  const token = useCookie<string>("auth_token");
  const currentUser = ref<User | null>();
  // Register
  const register = async (
    email: string,
    username: string,
    password: string
  ) => {
    const response = await fetch(
      `${config.public.API_BASE_URL}/user/register`,
      {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ email, username, password }),
      }
    );

    if (!response.ok) {
      const errorData = await response.json();
      throw new Error(errorData.message || "Register failed");
    }

    const data: Login = await response.json();

    token.value = data.token;
    return data;
  };

  // Login

  const login = async (username: string, password: string) => {
    try {
      const data = await $fetch<Login>(
        `${config.public.API_BASE_URL}/user/login`,
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },

          body: JSON.stringify({ username, password }),
        }
      );
      token.value = data.token;
      return data;
    } catch {
      throw new Error("Login failed");
    }
  };

  const getCurrentUser = async () => {
    if (currentUser.value != null) {
      return currentUser.value;
    }
    const {data, error} = await useFetch<User>(
      `${config.public.API_BASE_URL}/user`,
      {
        headers: {
          Authorization: `Bearer ${token.value}`,
        },
      }
    );

    if (error.value?.statusCode === 401) {
      //TODO: Add unauthorized page
      navigateTo("/welcome");
      return null;
    }

    currentUser.value = data.value;
    return currentUser.value;
  };

  const logout = () => {
    token.value = "";
    currentUser.value = null;
    navigateTo("/welcome");
  };

  const isAuthenticated = () => {
    return !!token.value;
  };

  return {
    register,
    getCurrentUser,
    login,
    logout,
    isAuthenticated,
  };
}
