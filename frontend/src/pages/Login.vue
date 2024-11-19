<template>
  <section class="h-100vh flex justify-center items-center">
    <div class="w-[90%] border-2 my-0 mx-auto p-4 rounded-2xl">
      <ToggleGroup type="single" v-model="optionUser" class="justify-start">
        <ToggleGroupItem
          value="user"
          aria-label="Toggle User"
          :disabled="optionUser === 'user'"
        >
          User
        </ToggleGroupItem>
        <ToggleGroupItem
          value="userAdmin"
          aria-label="Toggle User Admin"
          :disabled="optionUser === 'userAdmin'"
        >
          User Admin
        </ToggleGroupItem>
      </ToggleGroup>
      <form @submit.prevent="handleFormStandard" class="mt-4">
        <div class="grid w-full max-w-sm text-left gap-1.5 my-0 mx-auto">
          <Label for="user">User</Label>
          <Input
            id="user"
            type="text"
            placeholder="user"
            v-model="fieldUser"
            :class="
              fieldUser.length < 3 ? 'border-red-500' : 'border-green-500'
            "
          />
        </div>
        <div class="grid w-full max-w-sm text-left gap-1.5 my-0 mx-auto mt-4">
          <Label for="password">Password</Label>
          <div class="relative w-full max-w-sm items-center">
            <Input
              id="search"
              :type="IconShowPassword ? 'password' : 'text'"
              placeholder="password"
              v-model="fieldPassword"
              :class="
                fieldPassword.length < 3 ||
                (showSignOut && fieldPassword !== fieldRepeatPassword)
                  ? 'border-red-500'
                  : 'border-green-500'
              "
            />
            <span
              class="absolute end-0 inset-y-0 flex items-center justify-center px-4"
            >
              <Eye
                class="size-4"
                @click="showPassword"
                v-if="IconShowPassword"
              />
              <EyeOff
                class="size-4"
                @click="showPassword"
                v-if="!IconShowPassword"
              />
            </span>
          </div>
        </div>
        <section v-if="showSignOut">
          <div class="grid w-full max-w-sm text-left gap-1.5 my-0 mx-auto mt-4">
            <Label for="password">Repeat password</Label>
            <div class="relative w-full max-w-sm items-center">
              <Input
                id="search"
                :type="IconShowRepeatPassword ? 'password' : 'text'"
                placeholder="repeat password"
                v-model="fieldRepeatPassword"
                :class="
                  fieldRepeatPassword.length < 3 ||
                  fieldRepeatPassword !== fieldPassword
                    ? 'border-red-500'
                    : 'border-green-500'
                "
              />
              <span
                class="absolute end-0 inset-y-0 flex items-center justify-center px-4"
              >
                <Eye
                  class="size-4"
                  @click="showRepeatPassword"
                  v-if="IconShowRepeatPassword"
                />
                <EyeOff
                  class="size-4"
                  @click="showRepeatPassword"
                  v-if="!IconShowRepeatPassword"
                />
              </span>
            </div>
          </div>
          <div
            class="grid w-full max-w-sm text-left gap-1.5 my-0 mx-auto mt-4"
            v-if="optionUser === 'userAdmin'"
          >
            <Label for="password">Date of Birth</Label>
            <Popover>
              <PopoverTrigger as-child>
                <Button
                  variant="outline"
                  :class="
                    cn(
                      'w-[280px] justify-start text-left font-normal',
                      !value && 'text-muted-foreground',
                      value === undefined
                        ? 'border-red-500'
                        : 'border-green-500'
                    )
                  "
                >
                  <CalendarIcon class="mr-2 h-4 w-4" />
                  {{
                    value
                      ? df.format(value.toDate(getLocalTimeZone()))
                      : "Pick a date"
                  }}
                </Button>
              </PopoverTrigger>
              <PopoverContent class="w-auto p-0">
                <Calendar v-model="value" initial-focus />
              </PopoverContent>
            </Popover>
          </div>
          <div class="grid w-full max-w-sm text-left gap-1.5 my-0 mx-auto mt-4">
            <Label for="email">Email</Label>
            <Input
              id="email"
              type="text"
              placeholder="example@example.com"
              v-model="fieldEmail"
              :class="
                fieldEmail.length < 3 ? 'border-red-500' : 'border-green-500'
              "
            />
          </div>
        </section>
        <div v-if="!showSignOut">
          <Button class="mt-4" @click="signIn">Sign-in</Button>
          <Button class="mt-4 ml-2" @click="signOut">Sign-out</Button>
        </div>
        <div v-else>
          <Button class="mt-4" @click="sendSignOut">Send</Button>
          <Button class="mt-4 ml-2" @click="backSignin">Back</Button>
        </div>
      </form>
    </div>
  </section>
</template>

<script setup lang="ts">
import { ToggleGroup, ToggleGroupItem } from "@/components/ui/toggle-group";
import { Input } from "../components/ui/input";
import { Label } from "../components/ui/label";
import { Button } from "../components/ui/button";
import { Eye, EyeOff, Icon, Search } from "lucide-vue-next";
import { Calendar } from "@/components/ui/calendar";

import {
  Popover,
  PopoverContent,
  PopoverTrigger,
} from "@/components/ui/popover";
import { cn } from "@/lib/utils";
import {
  DateFormatter,
  type DateValue,
  getLocalTimeZone,
} from "@internationalized/date";
import { Calendar as CalendarIcon } from "lucide-vue-next";
import { h, ref, watch } from "vue";
import { toast } from "../components/ui/toast";
import ToastAction from "../components/ui/toast/ToastAction.vue";
import { useRouter } from "vue-router";

const optionUser = ref("user");
const IconShowPassword = ref(true);
const IconShowRepeatPassword = ref(true);
const showSignOut = ref(false);
const value = ref<DateValue>();
const fieldUser = ref("");
const fieldPassword = ref("");
const fieldRepeatPassword = ref("");
const fieldEmail = ref("");

const router = useRouter();

const showPassword = () => {
  IconShowPassword.value = !IconShowPassword.value;
};

const showRepeatPassword = () => {
  IconShowRepeatPassword.value = !IconShowRepeatPassword.value;
};

const handleFormStandard = () => {};

const signIn = () => {
  if (fieldUser.value === "" || fieldPassword.value === "") {
    toast({
      title: "User or password is empty",
      variant: "destructive",
      action: h(
        ToastAction,
        {
          altText: "Close",
        },
        {
          default: () => "Close",
        }
      ),
    });
    return;
  }

  if (optionUser.value === "user") {
    fetch("https://localhost:7181/api/UserStandard/LoginUser", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        user: fieldUser.value,
        password: fieldPassword.value,
      }),
    })
      .then((response) => {
        toast({
          title: "User successfully logged in",
          variant: "default",
          action: h(
            ToastAction,
            {
              altText: "Close",
            },
            {
              default: () => "Close",
            }
          ),
        });
        router.push("/");
        resetFields();
      })
      .catch((error) => {});
  } else if (optionUser.value === "userAdmin") {
    resetFields();
    console.log("login admin");
  }
};

watch(optionUser, () => {
  resetFields(false);
});

const signOut = () => {
  resetFields();
  showSignOut.value = !showSignOut.value;
};

const df = new DateFormatter("en-US", {
  dateStyle: "long",
});

const backSignin = () => {
  showSignOut.value = false;
  resetFields();
};

const resetFields = (reset?: boolean) => {
  fieldUser.value = "";
  fieldPassword.value = "";
  fieldRepeatPassword.value = "";
  value.value = undefined;
  IconShowPassword.value = true;
  reset && (showSignOut.value = false);
  // showSignOut.value = false;
};

const fieldsEmpty = () => {
  if (
    fieldUser.value === "" ||
    fieldPassword.value === "" ||
    fieldRepeatPassword.value === "" ||
    (optionUser.value === "userAdmin" && value.value === undefined) ||
    fieldEmail.value === ""
  ) {
    toast({
      title: "Fill in all fields in red",
      variant: "destructive",
      action: h(
        ToastAction,
        {
          altText: "Close",
        },
        {
          default: () => "Close",
        }
      ),
    });
    return true;
  } else {
    return false;
  }
};

const sendSignOut = () => {
  if (optionUser.value === "user") {
    if (fieldsEmpty()) {
      return;
    }
    resetFields();
    toast({
      title: "User create successfully",
      variant: "default",
      action: h(
        ToastAction,
        {
          altText: "Close",
        },
        {
          default: () => "Close",
        }
      ),
    });
  } else if (optionUser.value === "userAdmin") {
    console.log("sign out admin");
    toast({
      title: "User Admin create successfully",
      action: h(
        ToastAction,
        {
          altText: "Close",
        },
        {
          default: () => "Close",
        }
      ),
    });
  }
  // resetFields();
};
</script>