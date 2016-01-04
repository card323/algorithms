#include<iostream>

using namespace std;

void swap(int* a, int* b)
{
    int temp = *a;
    *a = *b;
    *b = temp;
}

void choose_key(int a[], int start, int end)
{
    int mid = start + (end - start) / 2;

    if (a[start] > a[mid])
    {
        if (a[mid] > a[end])
            swap(a + start, a + mid);
        else if (a[start] > a[end])
            swap(a + start, a + end);
    }
    else if (a[start] < a[end])
    {
        if (a[mid] > a[end])
            swap(a + start, a + end);
        else
            swap(a + start, a + mid);
    }
}

void quick_sort_part(int a[], int start, int end, int n)
{
    if (start >= end)
        return;

    int mid = start + (end - start) / 2;
    swap(a + start, a + mid);

    int left = start;
    int right = start + 1;
    int key = a[start];

    for (int i = start + 1; i <= end; i++)
    {
        if (a[i] > key)
            continue;
        else if (a[i] == key)
        {
            a[i] = a[right];
            a[right++] = key;
        }
        else
        {
            a[left++] = a[i];
            a[i] = a[right];
            a[right++] = key;
        }
    }

    if (left > n)
        quick_sort_part(a, start, left - 1, n);
    else if (n >= right)
        quick_sort_part(a, right, end, n);
}

int main()
{
    int n;
    long long k;
    cin >> n >> k;

    int* a = new int[n];
    long long* c = new long long[n];

    for (int i = 0; i < n; i++)
    {
        cin >> a[i];
    }
    k -= 1;
    quick_sort_part(a, 0, n - 1, k / n);


    int i1 = a[k / n];
    int size = 1;
    int left_size = 0;
    for (int i = k / n - 1; i >= 0; i--)
    {
        if (a[i] == i1)
            size++;
        else
        {
            left_size = i + 1;
            break;
        }
    }

    for (int i = k / n + 1; i < n; i++)
    {
        if (a[i] == i1)
            size++;
        else
            break;
    }

    k -= (long long)left_size*n;
    k /= size;
    if (k < left_size)
        quick_sort_part(a, 0, left_size - 1, k);
    else if (k >= left_size + size)
        quick_sort_part(a, left_size + size, n - 1, k);

    int i2 = a[k];
    cout << i1 << " " << i2 << endl;
    return 0;
}