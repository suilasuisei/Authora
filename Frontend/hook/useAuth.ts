"use client";

import { useRouter } from "next/navigation";
import { loginApi, registerApi } from "@/lib/api";

export function useAuth() {
  const router = useRouter();

  async function login(account: string, password: string) {
    try {
      const { ok, data } = await loginApi(account, password);
      alert(data);
      if (ok) {
        window.location.href = process.env.NEXT_PUBLIC_PROJECT0806_URL!;
      }
    } catch (error) {
      console.error("登入發生錯誤:", error);
      alert("無法連線到後端伺服器");
    }
  }

  async function register(account: string, password: string, userName: string) {
    try {
      const { ok, data } = await registerApi(account, password, userName);
      alert(data);
      if (ok) {
        router.push("/login");
      }
    } catch (error) {
      console.error("註冊發生錯誤:", error);
      alert("無法連線到後端伺服器");
    }
  }

  function logout() {
    router.push("/login");
  }

  return { login, register, logout };
}
