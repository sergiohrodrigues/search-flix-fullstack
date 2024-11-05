import { toast } from "vue-sonner";

export default () => {
    const alertSuccess = (titulo: string, color: string) => {
            toast.success(titulo, {
                action: {
                    label: "Close",
                    onClick: () => console.log("Undo"),
                },
                position: "top-right",
                style: { background: color },
            });
    };
    
    return {
        alertSuccess
    };
};