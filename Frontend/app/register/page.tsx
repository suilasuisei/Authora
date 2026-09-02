"use client";

import { Button } from "@/components/ui/button";
import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import Link from "next/link";
import { useState } from "react";
import { useAuth } from "@/hook/useAuth";

export default function Register() {
  const { register } = useAuth();

  const [account, setAccount] = useState("");
  const [password, setPassword] = useState("");
  const [userName, setUserName] = useState("");

  async function handleRegister() {
    await register(account, password, userName);
  }

  return (
    <main className="flex min-h-screen items-center justify-center">
      <Card className="w-full max-w-sm">
        <CardHeader>
          <CardTitle>註冊你的帳號</CardTitle>
          <CardDescription>輸入帳號、密碼與使用者名稱</CardDescription>
        </CardHeader>

        <CardContent>
          <form
            onSubmit={(e) => {
              e.preventDefault();
              handleRegister();
            }}
          >
            <div className="flex flex-col gap-6">
              {/* 帳號 */}
              <div className="grid gap-2">
                <Label htmlFor="account">帳號</Label>

                <Input
                  id="account"
                  type="text"
                  placeholder="請輸入帳號"
                  value={account}
                  onChange={(e) => setAccount(e.target.value)}
                  required
                />
              </div>

              {/* 密碼 */}
              <div className="grid gap-2">
                <Label htmlFor="password">密碼</Label>

                <Input
                  id="password"
                  type="password"
                  placeholder="請輸入密碼"
                  value={password}
                  onChange={(e) => setPassword(e.target.value)}
                  required
                />
              </div>

              {/* 使用者名稱 */}
              <div className="grid gap-2">
                <Label htmlFor="userName">使用者名稱</Label>

                <Input
                  id="userName"
                  type="text"
                  placeholder="請輸入使用者名稱"
                  value={userName}
                  onChange={(e) => setUserName(e.target.value)}
                  required
                />
              </div>

              {/* 註冊按鈕 */}
              <Button type="submit" className="w-full">
                註冊
              </Button>
            </div>
          </form>
        </CardContent>

        <CardFooter className="flex justify-center gap-2">
          <CardDescription>已經註冊？</CardDescription>

          <Link
            href="/login"
            className="text-sm underline-offset-4 hover:underline"
          >
            去登入
          </Link>
        </CardFooter>
      </Card>
    </main>
  );
}
