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
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import Link from "next/link";

export default function register() {
  return (
    <main className="flex min-h-screen items-center justify-center">
      <Card className="w-full max-w-sm">
        <CardHeader>
          <CardTitle>註冊你的帳號</CardTitle>
          <CardDescription>輸入帳號以註冊</CardDescription>
          <CardAction></CardAction>
        </CardHeader>
        <CardContent>
          <form>
            <div className="flex flex-col gap-6">
              <div className="grid gap-2">
                <Label htmlFor="account">帳號</Label>
                <Input id="account" type="account" placeholder="" required />
              </div>
              <div className="grid gap-2">
                <div className="flex items-center">
                  <Label htmlFor="password">密碼</Label>
                </div>
                <Input id="password" type="password" required />
              </div>
            </div>
          </form>
        </CardContent>
        <CardFooter className="flex-col gap-2">
          <Button type="submit" className="w-full">
            註冊
          </Button>
        </CardFooter>
        <div className="flex">
          <CardDescription className="ml-auto mr-3 items-center">
            已經註冊?
          </CardDescription>
          <Link
            href="/login"
            className=" mr-auto items-center text-sm underline-offset-4 hover:underline"
          >
            去登入
          </Link>
        </div>
      </Card>
    </main>
  );
}
