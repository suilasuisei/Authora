import * as React from "react";
import { Input as InputPrimitive } from "@base-ui/react/input";

import { cn } from "@/lib/utils";

function Input({ className, type, ...props }: React.ComponentProps<"input">) {
  return (
    <InputPrimitive
      type={type}
      data-slot="input"
      className={cn(
        "w-full rounded-lg border border-gray-300 px-4 py-2 outline-none transition focus:border-black focus:ring-1 focus:ring-black",
        className,
      )}
      {...props}
    />
  );
}

export { Input };
