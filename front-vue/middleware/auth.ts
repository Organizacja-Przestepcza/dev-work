import { useCookie } from "#app";
import { jwtDecode } from "jwt-decode";

export default defineNuxtRouteMiddleware(() => {
  const authCookie = useCookie("auth_token");
  if (authCookie == null || authCookie.value == "") {
    return navigateTo("/welcome");
  }
  authCookie.value = authCookie.value?.toString() ?? "";
  try {
    const decodedToken = jwtDecode(authCookie.value);
    if (!decodedToken.exp) return;

    if (decodedToken.exp * 1000 < Date.now()) {
      authCookie.value = "";
    }
  } catch {
    authCookie.value = "";
    return navigateTo("/welcome");
  }

  // Tutaj możesz także zweryfikować token na poziomie klienta, np. sprawdzając jego ważność
  // Możesz także wysłać token na serwer, aby sprawdzić, czy jest nadal ważny (np. przez API)
});
