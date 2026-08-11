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

export default function resetPassword() {
  return (
    <main className="flex min-h-screen items-center justify-center">
      <Card className="w-full max-w-sm">
        <CardHeader>
          <CardTitle>找回密碼</CardTitle>
          <CardDescription>輸入舊密碼</CardDescription>
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
                <Label htmlFor="account">電子信箱</Label>
                <Input
                  id="account"
                  type="account"
                  placeholder="m@example.com"
                  required
                />
              </div>
              <div className="grid gap-2">
                <div className="flex items-center">
                  <Label htmlFor="password">新密碼</Label>
                </div>
                <Input id="password" type="password" required />
              </div>
            </div>
          </form>
        </CardContent>
        <CardFooter className="flex-col gap-2">
          <Button type="submit" className="w-full">
            更新密碼
          </Button>
        </CardFooter>
        <div className="flex">
          <CardDescription className="ml-auto mr-3 items-center">
            想起密碼?
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
