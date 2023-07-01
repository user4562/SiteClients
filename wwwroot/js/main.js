const removeQuest = document.querySelector('.remove-wrapper');
const removeButtons = document.querySelectorAll('.button--delete');

const cancelButton = document.querySelector('.cancel');
const removeButton = document.querySelector('.remove');

const deleteId = document.querySelector('.deleteId');
const items = document.querySelectorAll('.client-item');

removeButtons.forEach(button => {
    button.addEventListener('click', e => {
        removeQuest.classList.add('remove-wrapper--active');

        items.forEach(item => {
            const butDetele = item.querySelector('.button--delete');
            if (butDetele == button) {
                deleteId.value = item.dataset.id;
            }
        });
    });
});

cancelButton.addEventListener('click', e => {
    removeQuest.classList.remove('remove-wrapper--active');
});

removeButton.addEventListener('click', e => {
    removeQuest.classList.remove('remove-wrapper--active');
});
