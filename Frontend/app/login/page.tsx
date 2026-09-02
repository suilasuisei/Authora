"use client";

import { Button } from "@/components/ui/button";
import {
  Card,
  CardAction,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { Label } from "@/components/ui/label";
import { Input } from "@/components/ui/input";
import Link from "next/link";
import { useState } from "react";
import { useAuth } from "@/hook/useAuth";

export default function Login() {
  const { login } = useAuth();
  const [account, setAccount] = useState("");
  const [password, setPassword] = useState("");

  async function handleLogin() {
    await login(account, password);
  }
  return (
    <main className="flex min-h-screen items-center justify-center">
      <Card className="w-full max-w-sm ">
        <CardHeader>
          <CardTitle>登入你的帳號</CardTitle>
          <CardDescription>輸入帳號及密碼以登入</CardDescription>
          <CardAction></CardAction>
        </CardHeader>
        <CardContent>
          <form>
            <div className="flex flex-col gap-6">
              <div className="grid gap-2">
                <Label htmlFor="account">帳號</Label>
                <Input
                  type="text"
                  id="account"
                  placeholder=""
                  value={account}
                  onChange={(e) => setAccount(e.target.value)}
                />
              </div>
              <div className="grid gap-2">
                <div className="flex items-center">
                  <Label htmlFor="password">密碼</Label>
                  <a
                    href="/resetPassword"
                    className="ml-auto inline-block text-sm underline-offset-4 hover:underline"
                  >
                    忘記密碼?
                  </a>
                </div>
                <Input
                  type="password"
                  id="password"
                  value={password}
                  onChange={(e) => setPassword(e.target.value)}
                />
              </div>
            </div>
          </form>
        </CardContent>
        <CardFooter className="flex-col gap-2">
          <Button type="button" onClick={handleLogin} className="w-full">
            登入
          </Button>
          <Button
            type="button"
            onClick={() => {
              window.location.href = `${process.env.NEXT_PUBLIC_API_URL}/api/google`;
            }}
          >
            使用 Google 登入
          </Button>
          <Button
            type="button"
            onClick={() => {
              window.location.href = `${process.env.NEXT_PUBLIC_API_URL}/line`;
            }}
          >
            使用 LINE 登入
          </Button>
        </CardFooter>
        <div className="flex">
          <CardDescription className="ml-auto mr-3 items-center">
            還未註冊?
          </CardDescription>
          <Link
            href="/register"
            className=" mr-auto items-center text-sm underline-offset-4 hover:underline"
          >
            註冊
          </Link>
        </div>
      </Card>
    </main>
  );
}
